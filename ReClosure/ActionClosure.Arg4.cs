namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2, TInput3> : IEquatable<ActionClosure<TInput0, TInput1, TInput2, TInput3>>
    {
        private Closure _context;
        private Action<Closure, TInput0, TInput1, TInput2, TInput3> _wrapper;

        public static implicit operator ActionClosure<TInput0, TInput1, TInput2, TInput3>(Action<TInput0, TInput1, TInput2, TInput3> action)
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

        public void Invoke(TInput0 arg, TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            if (_wrapper != null) 
                _wrapper(_context, arg, arg1, arg3, arg4);
        }

        public static ActionClosure<TInput0, TInput1, TInput2, TInput3> Create(Action<TInput0, TInput1, TInput2, TInput3> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure { _delegate = action },
                _wrapper = (c, arg0, arg1, arg2, arg3) => c.Invoke(arg0, arg1, arg2, arg3)
            };
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
