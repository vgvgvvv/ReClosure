using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public TResult RInvoke<T0, T1, T2, T3, TResult>()
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    SValue.Reader<T2>.Invoke(ref _2), 
                    SValue.Reader<T3>.Invoke(ref _3)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                var arg2 = SValue.Reader<T2>.Invoke(ref _2);
                var arg3 = SValue.Reader<T3>.Invoke(ref _3);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #region Bind1
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0, 
                    SValue.Reader<T1>.Invoke(ref _0),
                    SValue.Reader<T2>.Invoke(ref _1), 
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                var arg2 = SValue.Reader<T2>.Invoke(ref _1);
                var arg3 = SValue.Reader<T3>.Invoke(ref _2);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T1 arg1)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _1), 
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg2 = SValue.Reader<T2>.Invoke(ref _1);
                var arg3 = SValue.Reader<T3>.Invoke(ref _2);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    SValue.Reader<T1>.Invoke(ref _1), 
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                var arg3 = SValue.Reader<T3>.Invoke(ref _2);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    SValue.Reader<T1>.Invoke(ref _1), 
                    SValue.Reader<T2>.Invoke(ref _2),
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                var arg2 = SValue.Reader<T2>.Invoke(ref _2);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion
        
        #region Bind2
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T1 arg1)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _0),
                    SValue.Reader<T3>.Invoke(ref _1)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg2 = SValue.Reader<T2>.Invoke(ref _0);
                var arg3 = SValue.Reader<T3>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    SValue.Reader<T1>.Invoke(ref _0),
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _1)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                var arg3 = SValue.Reader<T3>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    SValue.Reader<T1>.Invoke(ref _0),
                    SValue.Reader<T2>.Invoke(ref _1),
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                var arg2 = SValue.Reader<T2>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T1 arg1, ref T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _1)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg3 = SValue.Reader<T3>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T1 arg1, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _1),
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg2 = SValue.Reader<T2>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T2 arg2, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    SValue.Reader<T1>.Invoke(ref _1),
                    arg2,
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion

        #region Bind3

        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T1 arg1, ref T2 arg2)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    arg1,
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _0)
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg3 = SValue.Reader<T3>.Invoke(ref _0);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T1 arg1, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _0),
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg2 = SValue.Reader<T2>.Invoke(ref _0);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T2 arg2, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    SValue.Reader<T1>.Invoke(ref _0),
                    arg2,
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    arg2,
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #endregion

        public TResult RInvoke<T0, T1, T2, T3, TResult>(ref T0 arg0, ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            if(_delegate is Func<T0, T1, T2, T3, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    arg1,
                    arg2,
                    arg3
                );
            }
            else if (_delegate is FuncByRef<T0, T1, T2, T3, TResult> funcByRef)
            {
                return funcByRef(ref arg0, ref arg1, ref arg2, ref arg3);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
    }
}