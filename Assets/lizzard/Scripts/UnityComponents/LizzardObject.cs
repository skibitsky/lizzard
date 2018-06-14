using lizzard.Interfaces;
using UnityEngine;

namespace lizzard.UnityComponents
{
    public class LizzardObject : MonoBehaviour, ILizzardObject
    {
        public int Id { get; set; }
        
        public GameObject GameObject { get; set; }
    }
}