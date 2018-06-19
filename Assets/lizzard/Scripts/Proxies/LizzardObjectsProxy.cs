using System.Collections.Generic;
using System.Linq;
using lizzard.Interfaces;
using lizzard.UnityComponents;
using UnityEngine;
using UnityPureMVC.Patterns;

namespace lizzard.Proxies
{
    public class LizzardObjectsProxy : Proxy
    {
        private int _id = 0;

        // Collection of all ILizzardObjects
        private readonly Dictionary<int, ILizzardObject> _objects = new Dictionary<int, ILizzardObject>();
        
        public LizzardObjectsProxy(string proxyName, object data = null) : base(proxyName, data)
        {
            
        }

        /// <summary>
        /// Add ILizzardObject to collection
        /// </summary>
        /// <param name="obj">ILIzzardObject which will be added</param>
        public virtual void AddObject(ILizzardObject obj)
        {
            // Save ILizzardObject unique ID
            obj.Id = _id++;
            // Add it to colelction
            _objects.Add(obj.Id, obj);
        }
        
        
        /// <summary>
        /// Register Unity GameObject as an ILizzardObject
        /// </summary>
        /// <param name="obj">GameObject to be regirestered</param>
        public virtual void AddObject(GameObject obj)
        {
            // If it doesn't have ILizzardObject component, create one
            if (obj.GetComponent<ILizzardObject>() == null)
                obj.AddComponent<LizzardObject>();

            var ilo = obj.GetComponent<ILizzardObject>();
            // Save GameObject
            ilo.GameObject = obj;
            // Save ILizzardObject unique ID
            ilo.Id = _id++;
            // Add it to collection
            _objects.Add(ilo.Id, ilo);
        }

        /// <summary>
        /// Gert ILizzardObject
        /// </summary>
        /// <param name="id">ILizzardObject id</param>
        public virtual ILizzardObject GetObject(int id)
        {
            if (_objects.ContainsKey(id))
                return _objects[id];
            
            Debug.LogErrorFormat("There is no ILizzardObject with ID: <b>{0}</b>", id);
            return null;
        }

        /// <summary>
        /// Remove LizazardObject from the collection
        /// </summary>
        /// <param name="id">Id of LizzardObject</param>
        /// <param name="destroy">Destroy GameObject?</param>
        /// <returns>Successfully removed?</returns>
        public virtual bool RemoveObject(int id, bool destroy)
        {
            if (!_objects.ContainsKey(id)) return false;

            if (destroy)
                Object.Destroy(_objects[id].GameObject);

            _objects.Remove(id);
            
            return true;
        }

        /// <summary>
        /// Remove LizazardObject from the collection
        /// </summary>
        /// <param name="obj">ILizzardObject</param>
        /// <param name="destroy">Destroy GameObject?</param>
        /// <returns>Successfully removed?</returns>
        public virtual bool RemoveObject(ILizzardObject obj, bool destroy)
        {
            if (!_objects.ContainsKey(obj.Id)) return false;

            if (destroy)
                Object.Destroy(_objects[obj.Id].GameObject);

            _objects.Remove(obj.Id);
            
            return true;
        }

        /// <summary>
        /// Deletes all LizzardObjects from the list if theri GameObject is null
        /// </summary>
        public virtual void DeleteAllNullObjects()
        {
            var dictionary = _objects
			    .Where(entry => entry.Value?.GameObject?.Equals(null) ?? true)
			    .ToDictionary(entry => entry.Key,
		        entry => entry.Value);

            foreach (var entry in dictionary)
            {
			    RemoveObject(entry.Key, false);
            }
        }

        public ILizzardObject GetLastObject()
        {
            return _objects[_id-1];
        }

        public int GetLastId()
        {
            return _id-1;
        }
    }
}