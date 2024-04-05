using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    public Button [] _menuButtons;
    [SerializeField] private int _indexButton = 0;
    public void Init()
    {
        for (int i = 0; i < _menuButtons.Length; i++)
        {
            _menuButtons[i].interactable = false;
        }
        
    }
    
    public void OnSetButtons(int indexButton)
    {
        if (indexButton >= _indexButton) _indexButton = indexButton;
        else
        {
            return;
        }

        for (int i = 0; i < _menuButtons.Length; i++)
        {
            _menuButtons[i].interactable = i <= _indexButton;
        }
    }
}
