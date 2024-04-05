using System.Collections;
using UnityEngine;

public class WelcomeController : BaseUIController
{
    [SerializeField] private WelcomeView view;
    [SerializeField] private string _labelWelcomeText;
    [SerializeField] private int _indexScreen = 1;
    [SerializeField ] private int _delay = 5;
    
    public override void Init()
    {
        base.Init();
        view._labelWelcomeText.text = _labelWelcomeText;
        StartCoroutine(Tools.Delay(_delay, () =>UIManager.Instance.SetCurrentScreen(_indexScreen)));
    }
}
