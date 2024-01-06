﻿namespace ReClosure
{
    public partial struct Closure
    {
        public void Invoke<T0, T1, T2, T3>()
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    SValue.Reader<T2>.Invoke(ref _2), 
                    SValue.Reader<T3>.Invoke(ref _3)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #region Bind1
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0, 
                    SValue.Reader<T1>.Invoke(ref _0),
                    SValue.Reader<T2>.Invoke(ref _1), 
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T1 arg1)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1, 
                    SValue.Reader<T2>.Invoke(ref _1), 
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T2 arg2)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    arg2, 
                    SValue.Reader<T3>.Invoke(ref _2)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    SValue.Reader<T2>.Invoke(ref _2), 
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #endregion
        
        #region Bind2
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0, 
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _0), 
                    SValue.Reader<T3>.Invoke(ref _1)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0, T2 arg2)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0, 
                    SValue.Reader<T1>.Invoke(ref _0),
                    arg2, 
                    SValue.Reader<T3>.Invoke(ref _1)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0, 
                    SValue.Reader<T1>.Invoke(ref _0),
                    SValue.Reader<T2>.Invoke(ref _1), 
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        public void Invoke<T0, T1, T2, T3>(T1 arg1, T2 arg2)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _1) 
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        public void Invoke<T0, T1, T2, T3>(T1 arg1, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _1),
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T2 arg2, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    SValue.Reader<T1>.Invoke(ref _1),
                    arg2,
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion

        #region Bind3

        public void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0,
                    arg1,
                    arg2,
                    SValue.Reader<T3>.Invoke(ref _0)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0,
                    arg1,
                    SValue.Reader<T2>.Invoke(ref _0),
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        public void Invoke<T0, T1, T2, T3>(T0 arg0, T2 arg2, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0,
                    SValue.Reader<T1>.Invoke(ref _0),
                    arg2,
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1,
                    arg2,
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        #endregion
        
        public void Invoke<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            if(_delegate is Action<T0, T1, T2, T3> act)
            {
                act.Invoke(
                    arg0,
                    arg1,
                    arg2,
                    arg3
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}