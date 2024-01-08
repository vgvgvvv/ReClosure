using System;

namespace ReClosure
{
    public partial struct Closure
    {
        public void Invoke<T>()
        {
            if (_delegate is Action<T> act)
            {
                act(SValue.Reader<T>.Invoke(ref _0));
            }
            else if (_delegate is ActionByRef<T> actionByRef)
            {
                var arg0 = SValue.Reader<T>.Invoke(ref _0);
                actionByRef(ref arg0);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }   
        
        public void Invoke<T>(ref T arg0)
        {
            if (_delegate is Action<T> act)
            {
                act(arg0);
            }
            else if (_delegate is ActionByRef<T> actionByRef)
            {
                actionByRef(ref arg0);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }   
    }
}