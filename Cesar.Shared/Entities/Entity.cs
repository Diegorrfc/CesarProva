using System;

namespace Cesar.Shared.Entities
{
    public abstract class Entity : Notification
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }        
        public Guid Id { get; set; }
    }
}