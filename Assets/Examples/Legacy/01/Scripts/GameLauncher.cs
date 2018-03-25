using UnityEngine;
using UnityPureMVC;

namespace lizzard.Examples01
{
    public class GameLauncher : MonoBehaviour
    {
        private void Awake()
        {
            UnityFacade.GetInstance.Startup();
        }
    }

}