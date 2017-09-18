using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class SpawnGameObjectCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            var spawnableObject = notification.Body as SpawnableGameObject;
            if (spawnableObject == null || spawnableObject.GameObject == null) return;
            Object.Instantiate(spawnableObject.GameObject,  spawnableObject.Position, 
                spawnableObject.Rotation, spawnableObject.ParentTransform);
        }
    }

    public class SpawnableGameObject
    {
        public SpawnableGameObject(GameObject gameObject, Transform parentTransform,
            Vector3 position, Quaternion rotation)
        {
            this.GameObject = gameObject;
            this.ParentTransform = parentTransform;
            this.Position = position;
            this.Rotation = rotation;
        }

        public GameObject GameObject;

        public Transform ParentTransform;

        public Vector3 Position;

        public Quaternion Rotation;
    }
}