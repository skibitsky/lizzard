using UnityEngine;
using UnityPureMVC.Patterns;

namespace lizzard.Examples02
{
    public class PlayerProxy : Proxy
    {
        private GameObject _playerPrefab;

        private GameObject _player;
        
        public PlayerProxy(string proxyName, object data = null) : base(proxyName, data)
        {
            LoadPlayerPrefab("Player02");
        }

        private void LoadPlayerPrefab(string name)
        {
            _playerPrefab = Resources.Load<GameObject>(name);
        }

        public GameObject GetPlayerPrefab()
        {
            return _playerPrefab;
        }

        public void AddPlayer(GameObject player)
        {
            _player = player;
        }

        public GameObject GetPlayer()
        {
            return _player;
        }
    }
}