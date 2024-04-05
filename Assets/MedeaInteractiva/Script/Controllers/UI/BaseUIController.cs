using UnityEngine;

public class BaseUIController : MonoBehaviour
{
  
   protected bool _isInit = false;
   public virtual void Init()
   {
      if (_isInit) return;
      
      _isInit = true;
   }
}
