using UnityPureMVC.Patterns;
using Fanchessy.Proxies;
using UnityPureMVC.Interfaces;

namespace Fanchessy.Commands
{
    // Registers all proxies
    public class StartupProxiesCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
//            Facade.RegisterProxy(new EngineProxy(ProxyNames.ENGINE_PROXY));
//            Facade.RegisterProxy(new NetworkProxy(ProxyNames.NETWORK_PROXY));
//            Facade.RegisterProxy(new LoginProxy(ProxyNames.LOGIN_PROXY));
//            Facade.RegisterProxy(new NetworkObjectsProxy(ProxyNames.NETWORK_OBJECTS_PROXY));
//            Facade.RegisterProxy(new NetworkRegionProxy(ProxyNames.NETWORK_REGION_PROXY));
//            Facade.RegisterProxy(new RoomProxy(ProxyNames.ROOM_PROXY));
//            Facade.RegisterProxy(new InventoryProxy(ProxyNames.INVENTORY_PROXY));
//            Facade.RegisterProxy(new ItemsProxy(ProxyNames.ITEMS_PROXY));
        }
    }
}