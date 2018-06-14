using lizzard.Proxies;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
	/// <inheritdoc />
	/// <summary>
	/// Register all lizzard's proxies
	/// </summary>
	public class StartupLizzardProxiesCommand : SimpleCommand
	{
		public override void Execute(INotification notification)
		{
			base.Execute(notification);
			Facade.RegisterProxy(new EngineProxy(ProxyNames.ENGINE_PROXY));
			Facade.RegisterProxy(new LizzardObjectsProxy(ProxyNames.LIZZARD_OBJECT_PROXY));
		}
	}
}