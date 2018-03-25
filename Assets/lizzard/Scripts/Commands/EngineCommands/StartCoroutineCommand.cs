using System.Collections;
using Fanchessy.Proxies;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace Fanchessy.Commands
{
    public class StartCoroutineCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            var engineProxy = Facade.RetrieveProxy(ProxyNames.ENGINE_PROXY) as EngineProxy;

            if (engineProxy != null) engineProxy.StartCoroutine((IEnumerator) notification.Body);
        }
    }
}