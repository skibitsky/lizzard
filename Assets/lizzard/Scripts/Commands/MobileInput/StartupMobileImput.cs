using System;
using System.Collections;
using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class StartupMobileImput : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            SendNotification(Notifications.START_COROUTINE, MobileInputUpdater(), null);
        }

        private IEnumerator MobileInputUpdater()
        {
            while (Application.isPlaying)
            {
                foreach (var touch in Input.touches)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            SendNotification(Notifications.TOUCH_BEGAN, touch, null);
                            break;
                        case TouchPhase.Ended:
                            SendNotification(Notifications.TOUCH_ENDED, touch, null);
                            break;
                        case TouchPhase.Canceled:
                            SendNotification(Notifications.TOUCH_CANCELED, touch, null);
                            break;
                        case TouchPhase.Moved:
                            SendNotification(Notifications.TOUCH_MOVED, touch, null);
                            break;
                        case TouchPhase.Stationary:
                             SendNotification(Notifications.TOUCH_STATIONARY, touch, null);
                             break;
                    }
                }

                yield return null;
            }
        }
    }
}