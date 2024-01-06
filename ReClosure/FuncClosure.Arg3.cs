namespace ReClosure
{
    public struct FuncClosure<TInput0, TInput1, TInput2>
    {
        private Closure _context;
        private Func<Closure, TInput0, TInput1, TInput2, SValue> _wrapper;

        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }

        public T Invoke<T>(TInput0 arg0, TInput1 arg1, TInput2 arg2)
        {
            if (_wrapper != null)
            {
                var s = _wrapper(_context, arg0, arg1, arg2);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }

        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2)
        {
            if (_wrapper != null) _wrapper(_context, arg0, arg1, arg2);
        }

        public static FuncClosure<TInput0, TInput1, TInput2> Create<TResult>(Func<TInput0, TInput1, TInput2, TResult> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<TResult>._default
            };
        }

        public static FuncClosure<TInput0, TInput1, TInput2> Create<T, TResult>(Func<T, TInput0, TInput1, TInput2, TResult> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T, TResult>._default
            };
        }

        public static FuncClosure<TInput0, TInput1, TInput2> Create(Action<TInput0, TInput1, TInput2> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = (e, arg0, arg1, arg2) =>
                {
                    e.Invoke(arg0, arg1, arg2);
                    return SValue.nil;
                }
            };
        }

        public static FuncClosure<TInput0, TInput1, TInput2> Create<T>(Action<T, TInput0, TInput1, TInput2> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T>._default
            };
        }
    
        internal class FuncClosureWrapper<TResult>
        {
            internal static Func<Closure, TInput0, TInput1, TInput2, SValue> _default = (e, arg0, arg1, arg2) => e.SRInvoke<TInput0, TInput1, TInput2, TResult>(arg0, arg1, arg2);
        }

        internal class FuncClosureWrapper<T, TResult>
        {
            internal static Func<Closure, TInput0, TInput1, TInput2, SValue> _default = (e, arg0, arg1, arg2) => e.SRInvoke<T, TInput0, TInput1, TInput2, TResult>(arg0, arg1, arg2);
        }
        

        internal class FuncClosureWrapper_VoidResult<T>
        {
            internal static Func<Closure, TInput0, TInput1, TInput2, SValue> _default = (e, arg0, arg1, arg2) =>
            {
                e.Invoke<T, TInput0, TInput1, TInput2>(arg0, arg1, arg2);
                return SValue.nil;
            };
        }
    }
}



