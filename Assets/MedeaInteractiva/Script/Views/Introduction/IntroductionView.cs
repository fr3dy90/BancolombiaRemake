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
    public GameObject[] screens;

    public void SetView(Sprite dialogueDataSpriteMoment)
    {
        for (int i = 0; i < momentImages.Length; i++)
        {
            momentImages[i].sprite = dialogueDataSpriteMoment;
        }
    }

    public void SetDialogue(string str, Action onComplete = null)
    {
        DialogueText.text = str;
        onComplete?.Invoke();
    }
    
    public void SetScreens(int index, Action onComplete = null)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == index);
        }
        onComplete?.Invoke();
    }
}
