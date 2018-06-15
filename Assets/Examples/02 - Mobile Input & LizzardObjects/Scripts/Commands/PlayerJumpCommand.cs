using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples02
{
    public class PlayerJumpCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            
            Debug.Log("Jump by touch in: " + ((Touch)notification.Body).rawPosition);
                        
            ((PlayerProxy) Facade.RetrieveProxy("PlayerProxy")).GetPlayer().
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }
}