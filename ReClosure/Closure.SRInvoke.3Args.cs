using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public SValue SRInvoke<T0, T1, T2, TResult>()
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0), 
                        SValue.Reader<T1>.Invoke(ref _1),
                        SValue.Reader<T2>.Invoke(ref _2)
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #region Bind1

        public SValue SRInvoke<T0, T1, T2, TResult>(T0 arg0)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0, 
                        SValue.Reader<T1>.Invoke(ref _0),
                        SValue.Reader<T2>.Invoke(ref _1)
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public SValue SRInvoke<T0, T1, T2, TResult>(T1 arg1)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0),
                        arg1, 
                        SValue.Reader<T2>.Invoke(ref _1)
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public SValue SRInvoke<T0, T1, T2, TResult>(T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0),
                        SValue.Reader<T1>.Invoke(ref _1),
                        arg2
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #endregion
        
        #region Bind2
        
        public SValue SRInvoke<T0, T1, T2, TResult>(T0 arg0, T1 arg1)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0,
                        arg1,
                        SValue.Reader<T2>.Invoke(ref _0)
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public SValue SRInvoke<T0, T1, T2, TResult>(T0 arg0, T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0,
                        SValue.Reader<T1>.Invoke(ref _0),
                        arg2
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public SValue SRInvoke<T0, T1, T2, TResult>(T1 arg1, T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        SValue.Reader<T0>.Invoke(ref _0),
                        arg1,
                        arg2
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion

        public SValue SRInvoke<T0, T1, T2, TResult>(T0 arg0, T1 arg1, T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, TResult> func)
            {
                return SValue.Writer<TResult>.Invoke(
                    func.Invoke(
                        arg0,
                        arg1,
                        arg2
                    )
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}