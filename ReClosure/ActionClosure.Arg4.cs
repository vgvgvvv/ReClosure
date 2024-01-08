using System;

namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2, TInput3> : IEquatable<ActionClosure<TInput0, TInput1, TInput2, TInput3>>
    {
        private Closure _context;
        private ActionByRef<Closure, TInput0, TInput1, TInput2, TInput3> _wrapper;

        public static implicit operator ActionClosure<TInput0, TInput1, TInput2, TInput3>(Action<TInput0, TInput1, TInput2, TInput3> action)
        {
            return Create(action);
        }
        
        public static implicit operator ActionClosure<TInput0, TInput1, TInput2, TInput3>(ActionByRef<TInput0, TInput1, TInput2, TInput3> action)
        {
            return Create(action);
        }
        
        public bool IsValid()
        {
            return _context.IsValid() && _wrapper != null;
        }
        
        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            arg0 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, ref TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, TInput1 arg1, out TInput2 arg3, TInput3 arg4)
        {
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, TInput1 arg1, TInput2 arg3, out TInput3 arg4)
        {
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            arg0 = default;
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, out TInput2 arg3, TInput3 arg4)
        {
            arg0 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, TInput1 arg1, TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, TInput2 arg3, out TInput3 arg4)
        {
            arg0 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg3, TInput3 arg4)
        {
            arg1 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg3, out TInput3 arg4)
        {
            arg1 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, ref TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, TInput1 arg1, out TInput2 arg3, out TInput3 arg4)
        {
            arg3 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg3, TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, out TInput2 arg3, TInput3 arg4)
        {
            arg0 = default;
            arg1 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg3, out TInput3 arg4)
        {
            arg0 = default;
            arg1 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, out TInput2 arg3, out TInput3 arg4)
        {
            arg0 = default;
            arg3 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg3, ref TInput3 arg4)
        {
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg3, out TInput3 arg4)
        {
            arg1 = default;
            arg3 = default;
            arg4 = default;
            Invoke(ref arg0, ref arg1, ref arg3, ref arg4);
        }

        public void Invoke(ref TInput0 arg, ref TInput1 arg1, ref TInput2 arg3, ref TInput3 arg4)
        {
            if (_wrapper != null) 
                _wrapper(ref _context, ref arg, ref arg1, ref arg3, ref arg4);
        }
        
        public void InvokeOut(out TInput0 arg, out TInput1 arg1, out TInput2 arg3, out TInput3 arg4)
        {
            arg = default;
            arg1 = default;
            arg3 = default;
            arg4 = default;
            Invoke(ref arg, ref arg1, ref arg3, ref arg4);
        }
        
        public static ActionClosure<TInput0, TInput1, TInput2, TInput3> Create(Action<TInput0, TInput1, TInput2, TInput3> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }
        
        public static ActionClosure<TInput0, TInput1, TInput2, TInput3> Create(ActionByRef<TInput0, TInput1, TInput2, TInput3> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }
        
        internal class ActionClosureWrapper
        {
            internal static ActionByRef<Closure, TInput0, TInput1, TInput2, TInput3> _default = Wrapper;

            private static void Wrapper(ref Closure closure, ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
            {
                closure.Invoke<TInput0, TInput1, TInput2, TInput3>(ref arg0, ref arg1, ref arg2, ref arg3);
            }
        }
        
        public bool Equals(ActionClosure<TInput0, TInput1, TInput2, TInput3> other)
        {
            return _context.Equals(other._context) && Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is ActionClosure<TInput0, TInput1, TInput2, TInput3> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_context.GetHashCode() * 397) ^ (_wrapper != null ? _wrapper.GetHashCode() : 0);
            }
        }
    }
}
