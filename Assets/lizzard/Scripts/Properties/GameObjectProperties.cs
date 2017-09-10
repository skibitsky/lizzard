using System.Collections;
using System.Collections.Generic;
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

        public string tag
        {
            get { return gameObject.tag; }
            set { gameObject.tag = value; }
        }
    }

}
