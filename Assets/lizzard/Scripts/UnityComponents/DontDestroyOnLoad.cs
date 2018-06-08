using UnityEngine;

namespace lizzard.UnityComponents
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

