﻿using System;

namespace ReClosure
{
    public struct FuncClosure : IEquatable<FuncClosure>
    {
        private Closure _context;
        private Func<Closure, SValue> _wrapper;
       
        public bool IsValid()
        {
            return _context.IsValid() && _wrapper != null;
        }
        
        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }

        public T Invoke<T>()
        {
            if (_wrapper != null)
            {
                var s = _wrapper(_context);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }

        public void Invoke()
        {
            if (_wrapper != null) _wrapper(_context);
        }

        public static FuncClosure Create<TResult>(Func<TResult> func)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<TResult>._default
            };
        }

        public static FuncClosure Create<T, TResult>(Func<T, TResult> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T, TResult>._default
            };
        }

        public static FuncClosure Create<T0, T1, TResult>(Func<T0, T1, TResult> func, T0 ctx0, T1 ctx1)
        {
            Closure.Check(func);
            return new FuncClosure
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

        public static FuncClosure Create<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(func);
            return new FuncClosure
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

        public static FuncClosure Create<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> func, T0 ctx0, T1 ctx1,
            T2 ctx2, T3 ctx3)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _3 = SValue.Writer<T3>.Invoke(ctx3),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper<T0, T1, T2, T3, TResult>._default
            };
        }

        public static FuncClosure Create(Action func)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = e =>
                {
                    e.Invoke();
                    return SValue.nil;
                }
            };
        }

        public static FuncClosure Create<T>(Action<T> func, T ctx)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T>._default
            };
        }

        public static FuncClosure Create<T0, T1>(Action<T0, T1> func, T0 ctx0, T1 ctx1)
        {
            Closure.Check(func);
            return new FuncClosure
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

        public static FuncClosure Create<T0, T1, T2>(Action<T0, T1, T2> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            Closure.Check(func);
            return new FuncClosure
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

        public static FuncClosure Create<T0, T1, T2, T3>(Action<T0, T1, T2, T3> func, T0 ctx0, T1 ctx1, T2 ctx2, T3 ctx3)
        {
            Closure.Check(func);
            return new FuncClosure
            {
                _context = new Closure
                {
                    _0 = SValue.Writer<T0>.Invoke(ctx0),
                    _1 = SValue.Writer<T1>.Invoke(ctx1),
                    _2 = SValue.Writer<T2>.Invoke(ctx2),
                    _3 = SValue.Writer<T3>.Invoke(ctx3),
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult<T0, T1, T2, T3>._default
            };
        }
    
        internal class FuncClosureWrapper<TResult>
        {
            internal static Func<Closure, SValue> _default = e => e.SRInvoke<TResult>();
        }

        internal class FuncClosureWrapper<T, TResult>
        {
            internal static Func<Closure, SValue> _default = e => e.SRInvoke<T, TResult>();
        }

        internal class FuncClosureWrapper<T0, T1, TResult>
        {
            internal static Func<Closure, SValue> _default = e => e.SRInvoke<T0, T1, TResult>();
        }

        internal class FuncClosureWrapper<T0, T1, T2, TResult>
        {
            internal static Func<Closure, SValue> _default = e => e.SRInvoke<T0, T1, T2, TResult>();
        }

        internal class FuncClosureWrapper<T0, T1, T2, T3, TResult>
        {
            internal static Func<Closure, SValue> _default = e => e.SRInvoke<T0, T1, T2, T3, TResult>();
        }

        internal class FuncClosureWrapper_VoidResult<T>
        {
            internal static Func<Closure, SValue> _default = e =>
            {
                e.Invoke<T>();
                return SValue.nil;
            };
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1>
        {
            internal static Func<Closure, SValue> _default = e =>
            {
                e.Invoke<T0, T1>();
                return SValue.nil;
            };
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1, T2>
        {
            internal static Func<Closure, SValue> _default = e =>
            {
                e.Invoke<T0, T1, T2>();
                return SValue.nil;
            };
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1, T2, T3>
        {
            internal static Func<Closure, SValue> _default = e =>
            {
                e.Invoke<T0, T1, T2, T3>();
                return SValue.nil;
            };
        }

        public bool Equals(FuncClosure other)
        {
            return _context.Equals(other._context) && 
                   Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosure other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_context.GetHashCode() * 397) ^ (_wrapper != null ? _wrapper.GetHashCode() : 0);
            }
        }
    }

    public struct FuncClosureR<TReturn> : IEquatable<FuncClosureR<TReturn>>
    {
        private FuncClosure _closure;

        public bool IsValid()
        {
            return _closure.IsValid();
        }
        
        public void Reset()
        {
           _closure.Reset();
        }

        public TReturn Invoke()
        {
            return _closure.Invoke<TReturn>();
        }

        public static FuncClosureR<TReturn> Create<TResult>(Func<TResult> func)
        {
            return new FuncClosureR<TReturn>
            {
                _closure = FuncClosure.Create(func)
            };
        }

        public static FuncClosureR<TReturn> Create<T, TResult>(Func<T, TResult> func, T ctx)
        {
            return new FuncClosureR<TReturn>()
            {
                _closure = FuncClosure.Create(func, ctx)
            };
        }

        public static FuncClosureR<TReturn> Create<T0, T1, TResult>(Func<T0, T1, TResult> func, T0 ctx0, T1 ctx1)
        {
            return new FuncClosureR<TReturn>()
            {
                _closure = FuncClosure.Create(func, ctx0, ctx1)
            };
        }

        public static FuncClosureR<TReturn> Create<T0, T1, T2, TResult>(Func<T0, T1, T2, TResult> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            return new FuncClosureR<TReturn>()
            {
                _closure = FuncClosure.Create(func, ctx0, ctx1, ctx2)
            };
        }

        public static FuncClosureR<TReturn> Create<T0, T1, T2, T3, TResult>(Func<T0, T1, T2, T3, TResult> func, T0 ctx0, T1 ctx1,
            T2 ctx2, T3 ctx3)
        {
            return new FuncClosureR<TReturn>()
            {
                _closure = FuncClosure.Create(func, ctx0, ctx1, ctx2, ctx3)
            };
        }
        
        public bool Equals(FuncClosureR<TReturn> other)
        {
            return _closure.Equals(other._closure);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosureR<TReturn> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _closure.GetHashCode();
        }
    }
}



