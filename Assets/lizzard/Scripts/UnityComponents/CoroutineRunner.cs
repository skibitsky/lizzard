using UnityEngine;
// ReSharper disable CheckNamespace

namespace Fanchessy.UnityComponents
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