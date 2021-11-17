using System.Collections.Generic;
using System.Linq;

namespace StarForum.Domain.Abstract
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            //check if both are null or both not null
            if(ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if(obj is null || obj.GetType() != GetType()) return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
        }

        public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }
    }
}