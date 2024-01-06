namespace ReClosure
{
    public struct FuncClosure<TInput0, TInput1, TInput2, TInput3>
    {
        private Closure _context;
        private Func<Closure, TInput0, TInput1, TInput2, TInput3, SValue> _wrapper;

        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }

        public T Invoke<T>(TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            if (_wrapper != null)
            {
                var s = _wrapper(_context, arg0, arg1, arg2, arg3);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }

        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            if (_wrapper != null) _wrapper(_context, arg0, arg1, arg2, arg3);
        }

        public static FuncClosure<TInput0, TInput1, TInput2, TInput3> Create<TResult>(Func<TInput0, TInput1, TInput2, TInput3, TResult> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<TResult>._default
            };
        }

        public static FuncClosure<TInput0, TInput1, TInput2, TInput3> Create(Action<TInput0, TInput1, TInput2, TInput3> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = (e, arg0, arg1, arg2, arg3) =>
                {
                    e.Invoke(arg0, arg1, arg2, arg3);
                    return SValue.nil;
                }
            };
        }
    
        private class FuncClosureWrapper<TResult>
        {
            internal static Func<Closure, TInput0, TInput1, TInput2, TInput3, SValue> _default = (e, arg0, arg1, arg2, arg3) => e.SRInvoke<TInput0, TInput1, TInput2, TInput3, TResult>(arg0, arg1, arg2, arg3);
        }
        
    }
}



