﻿using System;

namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2> : IEquatable<ActionClosure<TInput0, TInput1, TInput2>>
    {
        private Closure _context;
        private Action<Closure, TInput0, TInput1, TInput2> _wrapper;

        public static implicit operator ActionClosure<TInput0, TInput1, TInput2>(Action<TInput0, TInput1, TInput2> action)
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
                _wrapper(_context, arg, arg1, arg3);
        }

        public static ActionClosure<TInput0, TInput1, TInput2> Create(Action<TInput0, TInput1, TInput2> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure { _delegate = action },
                _wrapper = (c, arg0, arg1, arg2) => c.Invoke(arg0, arg1, arg2)
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

    
        internal class ActionClosureWrapper<T>
        {
            internal static Action<Closure, TInput0, TInput1, TInput2> _default = (e, arg0, arg1, arg2) => e.Invoke<T, TInput0, TInput1, TInput2>(arg0, arg1, arg2);
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