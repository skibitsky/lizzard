using UnityEngine;

namespace lizzard
{
    public class GameObjectProperties : MonoBehaviour
    {
        public bool IsActive
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }
    }
}
