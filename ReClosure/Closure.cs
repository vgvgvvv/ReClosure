using System.Diagnostics;

namespace ReClosure
{
    public partial struct Closure
    {
        public SValue _0;
        public SValue _1;
        public SValue _2;
        public SValue _3;
        public Delegate _delegate;

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
    }
}