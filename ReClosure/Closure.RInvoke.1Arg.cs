using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public TResult RInvoke<T, TResult>()
        {
            if(_delegate is Func<T, TResult> func)
            {
                return func.Invoke(SValue.Reader<T>.Invoke(ref _0));
            }
            else if (_delegate is FuncByRef<T, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T>.Invoke(ref _0);
                return funcByRef(ref arg0);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T, TResult>(ref T arg0)
        {
            if(_delegate is Func<T, TResult> func)
            {
                return func.Invoke(arg0);
            }
            else if (_delegate is FuncByRef<T, TResult> funcByRef)
            {
                return funcByRef(ref arg0);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}