using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    public class StartupProxiesCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            Facade.RegisterProxy(new ButtonsProxy("ButtonsProxy"));
        }
    }
}