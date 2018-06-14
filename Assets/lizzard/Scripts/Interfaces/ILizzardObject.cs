using UnityEngine;

namespace lizzard.Interfaces
{
    public interface ILizzardObject
    {
        int Id { get; set; }
        
        GameObject GameObject { get; set; }
    }
}