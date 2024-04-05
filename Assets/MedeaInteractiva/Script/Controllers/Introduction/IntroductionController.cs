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
    public static Action<Moment> onInit;


    public override void Init()
    {
        if (_isInit) return;
        base.Init();
        //SetIntroductionView(_actualMoment);
        view.introductonContinue.onClick.AddListener(()=> StartIntroductoin(_actualMoment));
        view.SetScreens(0);
        view.SetView( _actualMoment == Moment.Clasifica ? _dialogueDataClasifica.spriteMoment :  _dialogueDataConecta.spriteMoment);
    }
    
    public void StartIntroductoin(Moment moment)
    {
        _actualMoment = moment;
        StartCoroutine(Tools.Fade(1, 0, 1,_canvasGroup ,() =>
        {
            view.SetScreens(1, () =>
            {
                StartCoroutine(Tools.Fade(0,1,1,_canvasGroup, ()=> StartCoroutine(ShowMoment())));
                
            });
        }));
    }

    IEnumerator ShowMoment()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Tools.Fade(1,0,1,_canvasGroup,()=> view.SetScreens(2, () =>
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
        view.introductonEnd.gameObject.SetActive(false);
        StartCoroutine(Tools.Fade(0, 1, 1, _canvasGroup, null));
        for (int i = 0; i < data.dialogue.Length; i++)
        {
            view.SetDialogue(data.dialogue[i].dialogue);
            yield return StartCoroutine(Tools.Fade(0, 1, 1, _localCanvasGroup, null));
            yield return new WaitForSeconds(.8f);
            _audio. clip = data.dialogue[i].audio;
            _audio.Play();
            if (i == data.dialogue.Length - 1)
            {
                yield return new WaitForSeconds(data.dialogue[i].audio.length);
                view.introductonEnd.gameObject.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(data.dialogue[i].audio.length + .8f);
                yield return StartCoroutine( Tools.Fade(1, 0, 1, _localCanvasGroup, null));
            }
        }
    }
}

public enum Moment
{
    Clasifica,
    Conect
}
