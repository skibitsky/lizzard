using UnityEngine;

namespace Fanchessy.UnityComponents
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField]
        private Object _target;
        
        private void Awake()
        {
            DontDestroyOnLoad(_target);
        }
    }
}

