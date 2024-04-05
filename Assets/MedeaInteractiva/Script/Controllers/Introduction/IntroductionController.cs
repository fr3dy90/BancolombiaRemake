using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

public class IntroductionController : BaseUIController
{
    [SerializeField] private IntroductionView view;
    [SerializeField] private DialogueData _dialogueDataClasifica;
    [SerializeField] private DialogueData _dialogueDataConecta;
    [SerializeField] private Moment _actualMoment;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private CanvasGroup _localCanvasGroup;
    [SerializeField] private int _actualIndex;
    public static Action<Moment> onInit;


    public override void Init()
    {
        if (_isInit) return;
        base.Init();
        view.introductonContinue.onClick.AddListener(()=> StartIntroductoin(_actualMoment));
        view.SetScreens(0, 0);
        view.SetView( _actualMoment == Moment.Clasifica ? _dialogueDataClasifica.spriteMoment :  _dialogueDataConecta.spriteMoment);
        view.introductonEnd.onClick.AddListener(()=>StartCoroutine( Tools.Fade(1, 0, 1, _localCanvasGroup, () =>
        {
            StartCoroutine(ClasificaInstructions(_dialogueDataClasifica));
        })));
    }
    
    public void StartIntroductoin(Moment moment)
    {
        _actualMoment = moment;
        StartCoroutine(Tools.Fade(1, 0, 1,_canvasGroup ,() =>
        {
            view.SetScreens(1, 0,() =>
            {
                StartCoroutine(Tools.Fade(0,1,1,_canvasGroup, ()=> StartCoroutine(ShowMoment())));
                
            });
        }));
    }

    IEnumerator ShowMoment()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Tools.Fade(1,0,1,_canvasGroup,()=> view.SetScreens(2, 0,() =>
        {
            SetIntroductionView(_actualMoment);
        })));
    }
    
    public void SetIntroductionView(Moment moment)
    {
        StartCoroutine(moment == Moment.Clasifica ? OnMakeIntro(_dialogueDataClasifica) : OnMakeIntro(_dialogueDataConecta));
    }

    private IEnumerator OnMakeIntro(DialogueData data)
    {
        StartCoroutine(Tools.Fade(0, 1, 1, _canvasGroup, null));
        for (int i = 0; i < data.dialogue.Length; i++)
        {
            _actualIndex = i;
            if (i == 4)
            {
                view.SetScreens(2,1);
            }
            view.SetDialogue(i < 4 ? view.DialogueText : view.dialogueTitle, data.dialogue[i].dialogue);
            
            yield return StartCoroutine(Tools.Fade(0, 1, 1, _localCanvasGroup, null));
            yield return new WaitForSeconds(.8f);
            
            if (data.dialogue[i].audio != null)
            {
                _audio. clip = data.dialogue[i].audio;
                _audio.Play();
                yield return new WaitForSeconds(data.dialogue[i].audio.length + .8f);
            }
            else
            {
                yield return new WaitForSeconds(4f);
            }

            if (i == data.dialogue.Length - 3 && _actualMoment == Moment.Clasifica)
            {
                break;
                yield return StartCoroutine( Tools.Fade(1, 0, 1, _localCanvasGroup, null));
            }
        }

        if (_actualMoment == Moment.Conect)
        {
            StartCoroutine(Tools.Fade(1,0,1, _canvasGroup, null));
        }
    }

    private IEnumerator ClasificaInstructions(DialogueData data)
    {
        view.SetScreens(2,2);
        view.SetImagesBox(0, data.dialogue[5].dialogue);
        yield return StartCoroutine(Tools.Fade(0, 1, 1, _localCanvasGroup, null));
        yield return new WaitForSeconds(4);
        yield return StartCoroutine( Tools.Fade(1, 0, 1, _localCanvasGroup, null));
        view.SetImagesBox(1, data.dialogue[6].dialogue);
        yield return StartCoroutine(Tools.Fade(0, 1, 1, _localCanvasGroup, null));
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(Tools.Fade(1, 0, 1, _canvasGroup, null));
    }
}

public enum Moment
{
    Clasifica,
    Conect
}
