using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// Register all project's proxies
    /// </summary>
    public class StartupProxiesCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            Facade.RegisterProxy(new ButtonsProxy("ButtonsProxy"));
        }
    }
}