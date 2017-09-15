using UnityEngine;
using UnityPureMVC;
using UnityWeld.Binding;

namespace lizzard.Examples01
{
    [Binding]
    public class SpawnActionMediator : MonoBehaviourMediator
    {
        [Binding]
        public void Test()
        {
            Debug.Log("Debug mess");
        }
    }
}