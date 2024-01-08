using System;

namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2> : IEquatable<ActionClosure<TInput0, TInput1, TInput2>>
    {
        private Closure _context;
        private ActionByRef<Closure, TInput0, TInput1, TInput2> _wrapper;

        public static implicit operator ActionClosure<TInput0, TInput1, TInput2>(Action<TInput0, TInput1, TInput2> action)
        {
            return Create(action);
        }
        
        public static implicit operator ActionClosure<TInput0, TInput1, TInput2>(ActionByRef<TInput0, TInput1, TInput2> action)
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

        public void Invoke(TInput0 arg, TInput1 arg1, TInput2 arg3)
        {
            if (_wrapper != null) 
                _wrapper(ref _context, ref arg, ref arg1, ref arg3);
        }
        
        public void Invoke(ref TInput0 arg, ref TInput1 arg1, ref TInput2 arg3)
        {
            if (_wrapper != null) 
                _wrapper(ref _context, ref arg, ref arg1, ref arg3);
        }

        public static ActionClosure<TInput0, TInput1, TInput2> Create(Action<TInput0, TInput1, TInput2> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }
        
        public static ActionClosure<TInput0, TInput1, TInput2> Create(ActionByRef<TInput0, TInput1, TInput2> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }

        
        public static ActionClosure<TInput0, TInput1, TInput2> Create<T>(Action<T, TInput0, TInput1, TInput2> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }
        
        public static ActionClosure<TInput0, TInput1, TInput2> Create<T>(ActionByRef<T, TInput0, TInput1, TInput2> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }


        internal class ActionClosureWrapper
        {
            internal static ActionByRef<Closure, TInput0, TInput1, TInput2> _default = Wrapper;

            private static void Wrapper(ref Closure closure, ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2)
            {
                closure.Invoke<TInput0, TInput1, TInput2>(ref arg0, ref arg1, ref arg2);
            }
        }
        internal class ActionClosureWrapper<T>
        {
            internal static ActionByRef<Closure, TInput0, TInput1, TInput2> _default = Wrapper;
            
            private static void Wrapper(ref Closure closure, ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2)
            {
                closure.Invoke<T, TInput0, TInput1, TInput2>(ref arg0, ref arg1, ref arg2);
            }
        }

        public bool Equals(ActionClosure<TInput0, TInput1, TInput2> other)
        {
            return _context.Equals(other._context) && Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is ActionClosure<TInput0, TInput1, TInput2> other && Equals(other);
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
