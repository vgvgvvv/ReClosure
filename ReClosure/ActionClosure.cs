using System;
namespace ReClosure
{
    public struct ActionClosure : IEquatable<ActionClosure>
    {
        private Closure _context;
        private Action<Closure> _wrapper;
        
        public static implicit operator ActionClosure(Action action)
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

        public void Invoke()
        {
            if (_wrapper != null) 
                _wrapper(_context);
        }

        public static ActionClosure Create(Action action)
        {
            Closure.Check(action);
            return new ActionClosure
            {
                _context = new Closure { _delegate = action },
                _wrapper = e => e.Invoke()
            };
        }

        public static ActionClosure Create<T>(Action<T> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }

        public static ActionClosure Create<T0, T1>(Action<T0, T1> action, T0 ctx0, T1 ctx1)
        {
            Closure.Check(action);
            return new ActionClosure
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

        public static ActionClosure Create<T0, T1, T2>(Action<T0, T1, T2> action, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(action);
            return new ActionClosure
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

        public static ActionClosure Create<T0, T1, T2, T3>(Action<T0, T1, T2, T3> action, T0 ctx0, T1 ctx1, T2 ctx2,
            T3 ctx3)
        {
            Closure.Check(action);
            return new ActionClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _3 = SValue.Writer<T3>.Invoke(ctx3),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T0, T1, T2, T3>._default
            };
        }
    
        internal class ActionClosureWrapper<T>
        {
            internal static Action<Closure> _default = e => e.Invoke<T>();
        }

        internal class ActionClosureWrapper<T0, T1>
        {
            internal static Action<Closure> _default = e => e.Invoke<T0, T1>();
        }

        internal class ActionClosureWrapper<T0, T1, T2>
        {
            internal static Action<Closure> _default = e => e.Invoke<T0, T1, T2>();
        }

        internal class ActionClosureWrapper<T0, T1, T2, T3>
        {
            internal static Action<Closure> _default = e => e.Invoke<T0, T1, T2, T3>();
        }

        public bool Equals(ActionClosure other)
        {
            return _context.Equals(other._context) && 
                   Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is ActionClosure other && Equals(other);
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
