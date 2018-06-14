using lizzard.Proxies;
using lizzard.ValueObjects;
using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class InstantiateGameObjectCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            var spawnableObject = (InstantiateGameObjectVO)notification.Body;
            if (spawnableObject.GameObject == null) return;
            
            var go = Object.Instantiate(spawnableObject.GameObject,  spawnableObject.Position, 
                spawnableObject.Rotation, spawnableObject.ParentTransform);


            #region ILizzardObject

            var lop = Facade.RetrieveProxy(ProxyNames.LIZZARD_OBJECT_PROXY) as LizzardObjectsProxy;
 
            if (lop == null)
            {
                Debug.LogError("Cannot find LizzardObjectsProxy!");
                return;
            }

            // Register object into LizzardObjects collection with an unique ID
            lop.AddObject(go);

            #endregion
            
        }
    }
}