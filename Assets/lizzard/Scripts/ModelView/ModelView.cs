using UnityEngine;
using UnityPureMVC.Core;
using UnityWeld.Binding;

namespace lizzard
{
    [Binding]
    public class ModelView : MonoBehaviour
    {
        private string _key;

        [Binding]
        public virtual GameObject GameObject
        {
            get { return this.gameObject; }
        }

        public virtual void RegisterModelView(string key)
        {
            _key = key;
            View.GetInstance.RegisterModelView(_key, this);
        }

        private void OnDisable()
        {
            View.GetInstance.RemoveModelView(_key);
        }
    }
}