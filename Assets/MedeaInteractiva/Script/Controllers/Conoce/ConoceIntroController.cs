using UnityEngine;

public class ConoceIntroController : BaseController
{
    [SerializeField] private ConoceIntroView _conoceIntroView;
    [SerializeField] private int _index = 1;
    [TextArea(4,4), SerializeField] private string _introText;
    

    public override void Init()
   {
       if(isInit) return;
       base.Init();
       _conoceIntroView.SetText(_introText);
       _conoceIntroView._buttonContinue.onClick.AddListener(()=> ConoceController.OnInitScreen(1, true, null));
   }
}
