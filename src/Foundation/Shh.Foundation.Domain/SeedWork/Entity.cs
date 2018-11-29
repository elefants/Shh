using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Foundation.Domain.SeedWork
{
    public abstract class Entity<TId>
    {
        int? _requestedHashCode;
        TId _id;
        public virtual TId Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        public bool IsTransient()
        {
            return this.Id.ToString() == default(TId).ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TId>))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            var item = (Entity<TId>)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id.ToString() == this.Id.ToString();
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
