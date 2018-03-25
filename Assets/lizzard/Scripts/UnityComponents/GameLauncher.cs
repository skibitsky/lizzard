using UnityEngine;

namespace Fanchessy.UnityComponents
{
    /// <summary>
    /// Game's Papa
    /// </summary>
    public class GameLauncher : MonoBehaviour
    {
        private void Awake()
        {
            Facade.GetInstance.Startup();
        }
    }
}