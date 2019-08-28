using System.Collections.Generic;
using System.Linq;

namespace Cesar.Shared.Entities {
    public abstract class Notification {
        private IDictionary<string, string> _Notification;
        public IReadOnlyDictionary<string, string> Notifications => _Notification.ToDictionary (kv => kv.Key, kv => kv.Value);
        public Notification () {
            _Notification = new Dictionary<string, string> ();
        }
        public void AddNotification (string key, string value) {
            _Notification.Add (key, value);
        }
        public void AddNotifications (Notification notifications) {
            foreach (var item in notifications.Notifications) {
                AddNotification (item.Key, item.Value);
            }
        }
        public bool IsValid () {
            return _Notification?.Count == 0 ? true : false;
        }
        public bool IsInvalid () {
            return !IsValid ();
        }

    }
}