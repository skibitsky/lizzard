using lizzard.Commands;

namespace lizzard
{
    public class Facade : UnityPureMVC.Patterns.Facade
    {
        static Facade() { Instance = new Facade(); }

#pragma warning disable 108, 114
        public static Facade GetInstance { get { return Instance as Facade; } }
#pragma warning restore 108,114

        protected override void InitializeController()
        {
            base.InitializeController();
            RegisterCommand(Notifications.STARTUP_LIZZARD, typeof(StartupMacroCommand));
        }

        /// <summary>
        /// Call me to start the party!
        /// </summary>
        public virtual void Startup()
        {
            // Start lizzard's stuff (StartupMacroCommand, subscribed above)
            SendNotification(Notifications.STARTUP_LIZZARD);
            
            // Start project's stuff
            SendNotification(Notifications.STARTUP);
        }
    }

}