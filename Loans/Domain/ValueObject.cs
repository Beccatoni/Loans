﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Domain
{
    public abstract class ValueObject
    {

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if(ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
        
            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
        
            while(thisValues.MoveNext() && otherValues.MoveNext())
            {
                if(ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
        
                if(thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
        
          
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x,y) => x ^ y);
        }
    }
}
