﻿using System;

namespace ReClosure
{
    public struct FuncClosure<TInput0> : IEquatable<FuncClosure<TInput0>>
    {
        private Closure _context;
        private FuncByRef<Closure, TInput0, SValue> _wrapper;

        
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
                var s = _wrapper(ref _context, ref arg0);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }
        
        public T Invoke<T>(ref TInput0 arg0)
        {
            if (_wrapper != null)
            {
                var s = _wrapper(ref _context, ref arg0);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }
        
        public T InvokeOut<T>(out TInput0 arg0)
        {
            arg0 = default;
            return Invoke<T>(ref arg0);
        }

        public void Invoke(TInput0 arg0)
        {
            if (_wrapper != null)
            {
                _wrapper(ref _context, ref arg0);
            }
        }
        
        public void Invoke(ref TInput0 arg0)
        {
            if (_wrapper != null)
            {
                _wrapper(ref _context, ref arg0);
            }
        }
        
        public void InvokeOut(out TInput0 arg0)
        {
            arg0 = default;
            Invoke(ref arg0);
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
        
        public static FuncClosure<TInput0> Create<TResult>(FuncByRef<TInput0, TResult> func)
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
        
        public static FuncClosure<TInput0> Create<T, TResult>(FuncByRef<T, TInput0, TResult> func, T ctx)
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
        
        public static FuncClosure<TInput0> Create<T0, T1, TResult>(FuncByRef<T0, T1, TInput0, TResult> func, T0 ctx0, T1 ctx1)
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
        
        public static FuncClosure<TInput0> Create<T0, T1, T2, TResult>(FuncByRef<T0, T1, T2, TInput0, TResult> func, T0 ctx0, T1 ctx1, T2 ctx2)
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
                _wrapper = FuncClosureWrapper_VoidResult._default
            };
        }
        
        public static FuncClosure<TInput0> Create(ActionByRef<TInput0> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult._default
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
        
        public static FuncClosure<TInput0> Create<T>(ActionByRef<T, TInput0> func, T ctx)
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
        
        public static FuncClosure<TInput0> Create<T0, T1>(ActionByRef<T0, T1, TInput0> func, T0 ctx0, T1 ctx1)
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
        
        public static FuncClosure<TInput0> Create<T0, T1, T2>(ActionByRef<T0, T1, T2, TInput0> func, T0 ctx0, T1 ctx1, T2 ctx2)
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
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;

            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                return e.SRInvoke<TInput0, TResult>(ref arg0);
            }
        }

        internal class FuncClosureWrapper<T, TResult>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                return e.SRInvoke<T, TInput0, TResult>(ref arg0);
            }
        }

        internal class FuncClosureWrapper<T0, T1, TResult>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                return e.SRInvoke<T0, T1, TInput0, TResult>(ref arg0);
            }
        }

        internal class FuncClosureWrapper<T0, T1, T2, TResult>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                return e.SRInvoke<T0, T1, T2, TInput0, TResult>(ref arg0);
            }
        }


        internal class FuncClosureWrapper_VoidResult
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                e.Invoke<TInput0>(ref arg0);
                return SValue.nil;
            }
        }
        
        internal class FuncClosureWrapper_VoidResult<T>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;

            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                e.Invoke<T, TInput0>(ref arg0);
                return SValue.nil;
            }
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                e.Invoke<T0, T1, TInput0>(ref arg0);
                return SValue.nil;
            }
        }

        internal class FuncClosureWrapper_VoidResult<T0, T1, T2>
        {
            internal static FuncByRef<Closure, TInput0, SValue> _default = Wrapper;
            internal static SValue Wrapper(ref Closure e, ref TInput0 arg0)
            {
                e.Invoke<T0, T1, T2, TInput0>(ref arg0);
                return SValue.nil;
            }
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

    public struct FuncClosureR<TInput0, TReturn> : IEquatable<FuncClosureR<TInput0, TReturn>>
    {
        private FuncClosure<TInput0> _closure;
        
        public bool IsValid()
        {
            return _closure.IsValid();
        }
        
        public void Reset()
        {
            _closure.Reset();
        }
        
        public TReturn Invoke(TInput0 arg0)
        {
            return _closure.Invoke<TReturn>(ref arg0);
        }
        
        public TReturn Invoke(ref TInput0 arg0)
        {
            return _closure.Invoke<TReturn>(ref arg0);
        }
        
        public TReturn InvokeOut(out TInput0 arg0)
        {
            return _closure.InvokeOut<TReturn>(out arg0);
        }

        public static FuncClosureR<TInput0, TReturn> Create(Func<TInput0, TReturn> func)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func)
            };
        }

        public static FuncClosureR<TInput0, TReturn> Create(FuncByRef<TInput0, TReturn> func)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T>(Func<T, TInput0, TReturn> func, T ctx)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T>(FuncByRef<T, TInput0, TReturn> func, T ctx)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T0, T1>(Func<T0, T1, TInput0, TReturn> func, T0 ctx0, T1 ctx1)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx0, ctx1)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T0, T1>(FuncByRef<T0, T1, TInput0, TReturn> func, T0 ctx0, T1 ctx1)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx0, ctx1)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T0, T1, T2>(Func<T0, T1, T2, TInput0, TReturn> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx0, ctx1, ctx2)
            };
        }
        
        public static FuncClosureR<TInput0, TReturn> Create<T0, T1, T2>(FuncByRef<T0, T1, T2, TInput0, TReturn> func, T0 ctx0, T1 ctx1, T2 ctx2)
        {
            return new FuncClosureR<TInput0, TReturn>()
            {
                _closure = FuncClosure<TInput0>.Create(func, ctx0, ctx1, ctx2)
            };
        }

        public bool Equals(FuncClosureR<TInput0, TReturn> other)
        {
            return _closure.Equals(other._closure);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosureR<TInput0, TReturn> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _closure.GetHashCode();
        }
    }
}



