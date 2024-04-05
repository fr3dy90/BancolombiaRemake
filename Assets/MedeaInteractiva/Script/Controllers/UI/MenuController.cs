
using UnityEngine;

public class MenuController : BaseUIController
{
   [SerializeField] private MenuView _view;
   public override void Init()
   {
      if(_isInit) return;
      base.Init();
      
      _view.OnSetButtons(0);
      _view._menuButtons[0].onClick.AddListener(() =>
      {
         UIManager.Instance.SetCurrentScreen(2, () => ConoceController.OnInitScreen?.Invoke(0, false, null));
      });
      
      // Nueva funcion para el nuevo controlador de supermodal
      _view._menuButtons[1].onClick.AddListener(() =>
      {
         UIManager.Instance.SetCurrentScreen(3, null);
      });
   
      
      ConoceController.OnClose += () => _view.OnSetButtons(1);
   }
   
}
