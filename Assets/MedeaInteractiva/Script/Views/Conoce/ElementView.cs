using UnityEngine;
using UnityEngine.UI;

public class ElementView : MonoBehaviour
{
    public Image _imageElement;
    public Image _background;
    public GameObject _checkMark;
    
    public void InitElement(Element _element, Color col)
    {
        _imageElement.sprite = _element.sprite;
        _background.color = col;
        _checkMark.SetActive(false);
    }
    
    public void OnSelect(Color col)
    {
        _checkMark.SetActive(true);
        _background.color = col;
    }
}
