using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public void Invoke<T0, T1>()
        {
            if(_delegate is Action<T0, T1> act)
            {
                act(SValue.Reader<T0>.Invoke(ref _0), SValue.Reader<T1>.Invoke(ref _1));
            }
            else if (_delegate is ActionByRef<T0, T1> actionByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                var arg1 = SValue.Reader<T1>.Invoke(ref _1);
                actionByRef(ref arg0, ref arg1);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    
        public void Invoke<T0, T1>(ref T0 arg0)
        {
            if(_delegate is Action<T0, T1> act)
            {
                act(arg0, SValue.Reader<T1>.Invoke(ref _0));
            }
            else if (_delegate is ActionByRef<T0, T1> actionByRef)
            {
                var arg1 = SValue.Reader<T1>.Invoke(ref _0);
                actionByRef(ref arg0, ref arg1);    
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    
        public void Invoke<T0, T1>(ref T1 arg1)
        {
            if(_delegate is Action<T0, T1> act)
            {
                act(SValue.Reader<T0>.Invoke(ref _0), arg1);
            }
            else if (_delegate is ActionByRef<T0, T1> actionByRef)
            {
                var arg0 = SValue.Reader<T0>.Invoke(ref _0);
                actionByRef(ref arg0, ref arg1);    
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        public void Invoke<T0, T1>(ref T0 arg0, ref T1 arg1)
        {
            if(_delegate is Action<T0, T1> act)
            {
                act(arg0, arg1);
            }
            else if (_delegate is ActionByRef<T0, T1> actionByRef)
            {
                actionByRef(ref arg0, ref arg1);    
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

    }
}