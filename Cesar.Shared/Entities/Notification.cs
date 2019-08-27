using System.Collections.Generic;
using System.Linq;

namespace Cesar.Shared.Entities
{
    public abstract class Notification
    {
        private IDictionary<string, string> _Notification;
        public IReadOnlyDictionary<string, string> Notifications => _Notification.ToDictionary(kv => kv.Key, kv => kv.Value);

        public void AddNotification(string key, string value)
        {
            if (_Notification == null)
                _Notification = new Dictionary<string, string>();
            _Notification.Add(key, value);
        }
        public bool IsValid()
        {
            return _Notification.Count == 0 ? true : false;
        }
        public bool IsInvalid()
        {
            return !IsValid();
        }

    }
}