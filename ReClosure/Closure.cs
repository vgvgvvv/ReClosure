using System;
using System.Diagnostics;

namespace ReClosure
{
    public partial struct Closure : IEquatable<Closure> 
    {
        public SValue _0;
        public SValue _1;
        public SValue _2;
        public SValue _3;
        public Delegate _delegate;

        public bool IsValid()
        {
            return _delegate != null;
        }

        public T ctx_0<T>()
        {
            return SValue.Reader<T>.Invoke(ref _0);
        }

        public T ctx_1<T>()
        {
            return SValue.Reader<T>.Invoke(ref _1);
        }

        public T ctx_2<T>()
        {
            return SValue.Reader<T>.Invoke(ref _2);
        }

        public T ctx_3<T>()
        {
            return SValue.Reader<T>.Invoke(ref _3);
        }

        public void Reset()
        {
            _delegate = null;
            _0 = SValue.nil;
            _1 = SValue.nil;
            _2 = SValue.nil;
            _3 = SValue.nil;
        }

        [Conditional("DEBUG")]
        public static void Check(object d)
        {
            if (((Delegate)d).Target == null)
            {
                throw new Exception("Invoke invalid closure");
            }
        }

        public bool Equals(Closure other)
        {
            return _0.Equals(other._0) && 
                   _1.Equals(other._1) && 
                   _2.Equals(other._2) && 
                   _3.Equals(other._3) && 
                   Equals(_delegate, other._delegate);
        }

        public override bool Equals(object obj)
        {
            return obj is Closure other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _0.GetHashCode();
                hashCode = (hashCode * 397) ^ _1.GetHashCode();
                hashCode = (hashCode * 397) ^ _2.GetHashCode();
                hashCode = (hashCode * 397) ^ _3.GetHashCode();
                hashCode = (hashCode * 397) ^ (_delegate != null ? _delegate.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}