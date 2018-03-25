// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable InconsistentNaming

using lizzard.Commands;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    /// <summary>
    /// Defaul Facade to use or inherit from in Unity project
    /// </summary>
    public class UnityFacade : Facade
    { 
        static UnityFacade() { Instance = new UnityFacade(); }

        // Override 
#pragma warning disable 108,114
        public static UnityFacade GetInstance { get { return Instance as UnityFacade; } }
#pragma warning restore 108,114

        protected override void InitializeController()
        {
            base.InitializeController();
            RegisterCommand(NotificationNames.STARTUP, typeof(StartupMacroCommand));
            RegisterCommand(NotificationNames.SPAWN_GAMEOBJECT, typeof(SpawnGameObjectCommand));
        }

        public virtual void Startup()
        {
            SendNotification(NotificationNames.STARTUP);
        }

    }
}
