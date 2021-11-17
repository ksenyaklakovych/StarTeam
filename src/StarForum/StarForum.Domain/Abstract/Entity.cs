using System.Collections.Generic;
using MediatR;

namespace StarForum.Domain.Abstract
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return Id == default;
        }

        protected bool Equals(Entity other)
        {
            if(other.IsTransient() || this.IsTransient()) return false;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if(obj is not Entity)
                return false;
            
            if(ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            if(IsTransient()) return base.GetHashCode();

            return Id.GetHashCode() ^ 31;
        }

        public static bool operator==(Entity left, Entity right) => Equals(left, right);

        public static bool operator!=(Entity left, Entity right) => !Equals(left, right);
    }
}