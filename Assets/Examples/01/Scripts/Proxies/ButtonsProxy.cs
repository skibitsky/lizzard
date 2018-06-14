using UnityEngine;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    /// <summary>
    /// Proxy to work with buttons prefabs
    /// Resources folder is used as Model
    /// Buttons may be accessed very often therefore it is cashed into private var
    /// The var is private with a getter to unsure that nobody cannot accidentally substitute cashed data
    /// </summary>
    public class ButtonsProxy : Proxy
    {
        private GameObject _button;
        
        public ButtonsProxy(string proxyName, object data = null) : base(proxyName, data)
        {
            LoadButton("Btn_Action");
        }

        private void LoadButton(string name)
        {
            _button = Resources.Load<GameObject>(name);
        }

        public GameObject GetButton()
        {
            return _button;
        }
    }
}