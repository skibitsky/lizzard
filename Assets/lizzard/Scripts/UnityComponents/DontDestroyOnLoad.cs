using UnityEngine;

namespace lizzard.UnityComponents
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField]
        private Object _target;
        
        private void Awake()
        {
            if (_target == null) _target = gameObject;
            DontDestroyOnLoad(_target);
        }
    }
}

