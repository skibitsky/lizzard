using UnityEngine;

namespace lizzard.Examples01
{
    public class GameLauncher : MonoBehaviour
    {
        private void Awake()
        {
            // Here we can add our own Startup MacroCommand to init project's Mediators, Proxies, etc....
            Facade.GetInstance.RegisterCommand(Notifications.STARTUP, typeof(MyStartupMacroCommand));
            
            // Launch lizzard!
            Facade.GetInstance.Startup();
        }
    }

}