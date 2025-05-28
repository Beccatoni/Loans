using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Domain
{
    public abstract class Entity
    {
        int? _requestedHashCode;

        int _Id;

        public virtual int Id
        {
            get { return _Id; }
            protected set {  _Id = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity)) return false;

            if (Object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;

            Entity item = (Entity)obj;

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if(!_requestedHashCode.HasValue) _requestedHashCode = this.Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if(Object.Equals(left, null))
            {
                return (Object.Equals(right, null)) ? true: false;
            }
            else
            {
                return left.Equals(right);
            }

        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
