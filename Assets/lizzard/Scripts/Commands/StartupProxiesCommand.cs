using UnityPureMVC.Patterns;
using lizzard.Proxies;
using UnityPureMVC.Interfaces;

namespace lizzard.Commands
{
    // Registers all proxies
    public class StartupProxiesCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            Facade.RegisterProxy(new EngineProxy(ProxyNames.ENGINE_PROXY));
        }
    }
}