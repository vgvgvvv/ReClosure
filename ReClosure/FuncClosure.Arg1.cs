namespace ReClosure
{
    public struct FuncClosure<TInput0> : IEquatable<FuncClosure<TInput0>>
    {
        private Closure _context;
        private Func<Closure, TInput0, SValue> _wrapper;

        
        public bool IsValid()
        {
            return _context.IsValid() && _wrapper != null;
        }
        
        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }

        public T Invoke<T>(TInput0 arg0)
        {
            if (_wrapper != null)
            {
                var s = _wrapper(_context, arg0);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }

        public void Invoke(TInput0 arg0)
        {
            if (_wrapper != null) _wrapper(_context, arg0);
        }

        public static FuncClosure<TInput0> Create<TResult>(Func<TInput0, TResult> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<TResult>._default
            };
        }

        public static FuncClosure<TInput0> Create<T, TResult>(Func<T, TInput0, TResult> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T, TResult>._default
            };
        }

        public static FuncClosure<TInput0> Create<T0, T1, TResult>(Func<T0, T1, TInput0, TResult> func, T0 ctx0, T1 ctx1)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T0, T1, TResult>._default
            };
        }

        public static FuncClosure<TInput0> Create<T0, T1, T2, TResult>(Func<T0, T1, T2, TInput0, TResult> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T0, T1, T2, TResult>._default
            };
        }

        public static FuncClosure<TInput0> Create(Action<TInput0> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = (e, arg0) =>
                {
                    e.Invoke(arg0);
                    return SValue.nil;
                }
            };
        }

        public static FuncClosure<TInput0> Create<T>(Action<T, TInput0> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T>._default
            };
        }

        public static FuncClosure<TInput0> Create<T0, T1>(Action<T0, T1, TInput0> func, T0 ctx0, T1 ctx1)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T0, T1>._default
            };
        }

        public static FuncClosure<TInput0> Create<T0, T1, T2>(Action<T0, T1, T2, TInput0> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T0, T1, T2>._default
            };
        }
        
    
        internal class FuncClosureWrapper<TResult>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) => e.SRInvoke<TInput0, TResult>(arg0);
        }

        internal class FuncClosureWrapper<T, TResult>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) => e.SRInvoke<T, TInput0, TResult>(arg0);
        }

        internal class FuncClosureWrapper<T0, T1, TResult>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) => e.SRInvoke<T0, T1, TInput0, TResult>(arg0);
        }

        internal class FuncClosureWrapper<T0, T1, T2, TResult>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) => e.SRInvoke<T0, T1, T2, TInput0, TResult>(arg0);
        }
        

        internal class FuncClosureWrapper_VoidResult<T>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) =>
            {
                e.Invoke<T, TInput0>(arg0);
                return SValue.nil;
            };
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) =>
            {
                e.Invoke<T0, T1, TInput0>(arg0);
                return SValue.nil;
            };
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1, T2>
        {
            internal static Func<Closure, TInput0, SValue> _default = (e, arg0) =>
            {
                e.Invoke<T0, T1, T2, TInput0>(arg0);
                return SValue.nil;
            };
        }

        public bool Equals(FuncClosure<TInput0> other)
        {
            return _context.Equals(other._context) && Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosure<TInput0> other && Equals(other);
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



