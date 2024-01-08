using System;

namespace ReClosure
{
    public struct ActionClosure<TInput0>: IEquatable<ActionClosure<TInput0>>
    {
        private Closure _context;
        private ActionByRef<Closure, TInput0> _wrapper;

        public static implicit operator ActionClosure<TInput0>(Action<TInput0> action)
        {
            return Create(action);
        }
        
        public static implicit operator ActionClosure<TInput0>(ActionByRef<TInput0> action)
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

        public void Invoke(TInput0 arg)
        {
            if (_wrapper != null) 
                _wrapper(ref _context, ref arg);
        }
        
        public void Invoke(ref TInput0 arg)
        {
            if (_wrapper != null) 
                _wrapper(ref _context, ref arg);
        }

        public static ActionClosure<TInput0> Create(Action<TInput0> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }
        
        public static ActionClosure<TInput0> Create(ActionByRef<TInput0> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure { _delegate = action },
                _wrapper = ActionClosureWrapper._default
            };
        }

        public static ActionClosure<TInput0> Create<T>(Action<T, TInput0> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }
        
        public static ActionClosure<TInput0> Create<T>(ActionByRef<T, TInput0> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }

        public static ActionClosure<TInput0> Create<T0, T1>(Action<T0, T1, TInput0> action, T0 ctx0, T1 ctx1)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T0, T1>._default
            };
        }
        
        public static ActionClosure<TInput0> Create<T0, T1>(ActionByRef<T0, T1, TInput0> action, T0 ctx0, T1 ctx1)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T0, T1>._default
            };
        }

        public static ActionClosure<TInput0> Create<T0, T1, T2>(Action<T0, T1, T2, TInput0> action, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T0, T1, T2>._default
            };
        }
        
        public static ActionClosure<TInput0> Create<T0, T1, T2>(ActionByRef<T0, T1, T2, TInput0> action, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T0, T1, T2>._default
            };
        }

        internal class ActionClosureWrapper
        {
            internal static ActionByRef<Closure, TInput0> _default = Wrapper;
            private static void Wrapper(ref Closure closure, ref TInput0 arg0)
            {
                closure.Invoke<TInput0>(ref arg0);
            }
        }
        
        internal class ActionClosureWrapper<T>
        {
            internal static ActionByRef<Closure, TInput0> _default = Wrapper;
            
            private static void Wrapper(ref Closure closure, ref TInput0 arg0)
            {
                closure.Invoke<T, TInput0>(ref arg0);
            }
        }

        internal class ActionClosureWrapper<T0, T1>
        {
            internal static ActionByRef<Closure, TInput0> _default = Wrapper;
            private static void Wrapper(ref Closure closure, ref TInput0 arg0)
            {
                closure.Invoke<T0, T1, TInput0>(ref arg0);
            }
        }

        internal class ActionClosureWrapper<T0, T1, T2>
        {
            internal static ActionByRef<Closure, TInput0> _default = Wrapper;
            private static void Wrapper(ref Closure closure, ref TInput0 arg0)
            {
                closure.Invoke<T0, T1, T2, TInput0>(ref arg0);
            }
        }

        public bool Equals(ActionClosure<TInput0> other)
        {
            return _context.Equals(other._context) && Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is ActionClosure<TInput0> other && Equals(other);
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
