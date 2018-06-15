using System.Collections;
using System.Collections.Generic;
using lizzard.Examples02.Commands;
using UnityEngine;

namespace lizzard.Examples02
{
	public class GameLauncher : MonoBehaviour {
	
		private void Awake()
		{
			#if UNITY_IOS || UNITY_ANDROID
			// Here we can add our own Startup MacroCommand to init project's Mediators, Proxies, etc....
			Facade.GetInstance.RegisterCommand(Notifications.STARTUP, typeof(MyStartupMacroCommand));
            
			// Launch lizzard!
			Facade.GetInstance.Startup();
	
			return;
			#endif
			
			Debug.LogWarning("In order to run Example-02, please switch platform to iOS or Android");
		}
	}

}