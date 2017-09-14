// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable InconsistentNaming

namespace UnityPureMVC.Unity
{
    /// <summary>
    /// Defaul Facade to use or inherit from in Unity project
    /// </summary>
    public class UnityFacade : Patterns.Facade
    {
        
        public const string STARTUP = "UnityFacade.StartUp";

        static UnityFacade() { Instance = new UnityFacade(); }

        // Override 
#pragma warning disable 108,114
        public static UnityFacade GetInstance { get { return Instance as UnityFacade; } }
#pragma warning restore 108,114

        public virtual void Startup()
        {
            SendNotification(STARTUP);
        }

    }
}
