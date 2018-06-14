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
            Object.Instantiate(spawnableObject.GameObject,  spawnableObject.Position, 
                spawnableObject.Rotation, spawnableObject.ParentTransform);
        }
    }
}