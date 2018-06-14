using UnityEngine;

namespace lizzard.ValueObjects
{
    public struct InstantiateGameObjectVO
    {
        public InstantiateGameObjectVO(GameObject gameObject, Transform parentTransform,
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