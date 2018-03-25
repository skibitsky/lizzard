using Fanchessy.Commands;

namespace Fanchessy
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
            RegisterCommand(Notifications.STARTUP, typeof(StartupMacroCommand));
        }

        /// <summary>
        /// Call me to start the party!
        /// </summary>
        public virtual void Startup()
        {
            SendNotification(Notifications.STARTUP);
        }
    }

}