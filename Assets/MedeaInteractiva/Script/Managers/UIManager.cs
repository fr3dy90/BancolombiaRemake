using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public static UIManager Instance;

   [SerializeField] private BaseUIController[] _uIControllers;
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private int _indexScreen = 0;
   [SerializeField, InspectorButton("InitInspector")] private string label = "On Init";
   
private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(this);
      }
      
      if(GameManager.Instance != null && GameManager.Instance.isDebug)
      {
         OnInit(_indexScreen);
      }
   }

   private void InitInspector()
   {
      OnInit(_indexScreen);
   }

   public void OnInit(int indexScreen)
   {
      OnSetUIScreen(_indexScreen);
   }

   private void OnSetUIScreen(int indexScreen, Action onComplete = null)
   {
      for (int i = 0; i < _uIControllers.Length; i++)
      {
         _uIControllers[i].gameObject.SetActive(i == indexScreen);
         if (i == indexScreen)
         {
            _uIControllers[indexScreen].Init();
         }
      }
      StartCoroutine(Tools.Fade(0,1, 1, _canvasGroup, () =>
      {
         onComplete?.Invoke();
      }));
   }

   public void SetCurrentScreen(int indexScreen, Action onComplete = null)
   {
      StartCoroutine(Tools.Fade(1, 0, 1, _canvasGroup, () =>
      {
         OnSetUIScreen(indexScreen, () =>
         {
            onComplete?.Invoke();
         });
      }));
   }
}
