using UnityEngine;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
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