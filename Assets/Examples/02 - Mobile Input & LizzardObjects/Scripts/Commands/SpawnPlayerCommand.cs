using lizzard.Proxies;
using lizzard.ValueObjects;
using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples02
{
    public class SpawnPlayerCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            
            SendNotification(Notifications.INSTANTIATE,
                new InstantiateGameObjectVO(
                    ((PlayerProxy)Facade.RetrieveProxy("PlayerProxy")).GetPlayerPrefab(), 
                    GameObject.Find("World").transform,
                    new Vector3(0, 0, 0), 
                    Quaternion.identity),
                null
                );

            var playerGo = ((LizzardObjectsProxy) Facade.RetrieveProxy(ProxyNames.LIZZARD_OBJECT_PROXY))
                .GetLastObject()
                .GameObject;
            
            Debug.Log("Spawned: " + playerGo.name);
            
            ((PlayerProxy) Facade.RetrieveProxy("PlayerProxy")).AddPlayer(playerGo);
        }
    }
}