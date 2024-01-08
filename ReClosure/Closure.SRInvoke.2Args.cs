using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public SValue SRInvoke<T0, T1, TResult>()
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0), 
                        SValue.Reader<T1>.Invoke(ref _1)
                    )
                );
            }
            else if (_delegate is FuncByRef<T0, T1, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                return SValue.Writer<TResult>.Invoke(funcByRef(ref arg0, ref arg1));
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #region Bind1
        
        public SValue SRInvoke<T0, T1, TResult>(ref T0 arg0)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0,
                        SValue.Reader<T1>.Invoke(ref _0) 
                    )
                );
            }
            else if (_delegate is FuncByRef<T0, T1, TResult> funcByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                return SValue.Writer<TResult>.Invoke(funcByRef(ref arg0, ref arg1));
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public SValue SRInvoke<T0, T1, TResult>(ref T1 arg1)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0), 
                        arg1
                    )
                );
            }
            else if (_delegate is FuncByRef<T0, T1, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                return SValue.Writer<TResult>.Invoke(funcByRef(ref arg0, ref arg1));
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion
        
        public SValue SRInvoke<T0, T1, TResult>(ref T0 arg0, ref T1 arg1)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0, 
                        arg1
                    )
                );
            }
            else if (_delegate is FuncByRef<T0, T1, TResult> funcByRef)
            {
                return SValue.Writer<TResult>.Invoke(funcByRef(ref arg0, ref arg1));
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}