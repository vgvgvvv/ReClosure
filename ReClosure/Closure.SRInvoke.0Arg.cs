using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public SValue SRInvoke<TResult>()
        {
            if(_delegate is Func<TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(func.Invoke());
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}