using UnityEngine;
// ReSharper disable CheckNamespace

namespace lizzard.UnityComponents
{
    public class CoroutineRunner : MonoBehaviour
    {
        public static CoroutineRunner Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }
    }
}