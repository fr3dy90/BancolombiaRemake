using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionView : MonoBehaviour
{
    public Image[] momentImages;
    public Button introductonContinue;
    public Button introductonEnd;
    public TMP_Text DialogueText;
    public TMP_Text dialogueTitle;
    public TMP_Text iconsText;
    public GameObject[] screens;
    public GameObject[] contentBox;
    public GameObject[] imagesBox;

    public void SetView(Sprite dialogueDataSpriteMoment)
    {
        for (int i = 0; i < momentImages.Length; i++)
        {
            momentImages[i].sprite = dialogueDataSpriteMoment;
        }
    }

    public void SetDialogue(TMP_Text txt ,string str, Action onComplete = null)
    {
        txt.text = str;
        onComplete?.Invoke();
    }
    
    public void SetScreens(int index, int indexContent , Action onComplete = null)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == index);
        }
        
        for (int i = 0; i < contentBox.Length; i++)
        {
            contentBox[i].SetActive(i == indexContent);
        }
        onComplete?.Invoke();
    }
    
    public void SetImagesBox(int index, string srt)
    {
        SetDialogue(iconsText, srt);   
        for (int i = 0; i < imagesBox.Length; i++)
        {
            imagesBox[i].SetActive(i == index);
        }
    }
    
    
}
