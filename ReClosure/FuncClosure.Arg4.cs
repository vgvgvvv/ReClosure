using System;

namespace ReClosure
{
    public struct FuncClosure<TInput0, TInput1, TInput2, TInput3> : IEquatable<FuncClosure<TInput0, TInput1, TInput2, TInput3>>
    {
        private Closure _context;
        private FuncByRef<Closure, TInput0, TInput1, TInput2, TInput3, SValue> _wrapper;

        public bool IsValid()
        {
            return _context.IsValid() && _wrapper != null;
        }
        
        public void Reset()
        {
            _wrapper = null;
            _context.Reset();
        }

        public T Invoke<T>(TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #region Ref1
        public T Invoke<T>(ref TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg2 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        #endregion
        
        #region Ref2
        public T Invoke<T>(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(ref TInput0 arg0,  TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0,  TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(ref TInput0 arg0,  TInput1 arg1,  TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0,  TInput1 arg1,  TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0,  TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0,  TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg2 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion
        
        #region Ref3
        
        public T Invoke<T>(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(out TInput0 arg0, TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T Invoke<T>(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public T InvokeOut<T>(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion
        
        public T Invoke<T>(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            if (_wrapper != null)
            {
                var s = _wrapper(ref _context, ref arg0, ref arg1, ref arg2, ref arg3);
                return SValue.Reader<T>.Invoke(ref s);
            }

            return default;
        }
        
        public T InvokeOut<T>(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            arg3 = default;
            return Invoke<T>(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #region Ref1
        public void Invoke(ref TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        #endregion
        
        #region Ref2
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref TInput0 arg0,  TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0,  TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref TInput0 arg0,  TInput1 arg1,  TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0,  TInput1 arg1,  TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0,  TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0,  TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion
        
        #region Ref3
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out TInput0 arg0, TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion
        
        public void Invoke(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            if (_wrapper != null)
            {
                _wrapper(ref _context, ref arg0, ref arg1, ref arg2, ref arg3);
            }
        }
        
        public void InvokeOut(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
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
        
        public static FuncClosure<TInput0, TInput1, TInput2, TInput3> Create<TResult>(FuncByRef<TInput0, TInput1, TInput2, TInput3, TResult> func)
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
                _wrapper = FuncClosureWrapper_VoidResult._default
            };
        }
        
        public static FuncClosure<TInput0, TInput1, TInput2, TInput3> Create(ActionByRef<TInput0, TInput1, TInput2, TInput3> func)
        {
            Closure.Check(func);
            return new FuncClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _context = new Closure
                {
                    _delegate = func
                },
                _wrapper = FuncClosureWrapper_VoidResult._default
            };
        }
    
        private class FuncClosureWrapper<TResult>
        {
            internal static FuncByRef<Closure, TInput0, TInput1, TInput2, TInput3, SValue> _default = Wrapper;

            private static SValue Wrapper(ref Closure e, ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2,
                ref TInput3 arg3)
            {
                return e.SRInvoke<TInput0, TInput1, TInput2, TInput3, TResult>(ref arg0, ref arg1, ref arg2, ref arg3);
            }
        }

        private class FuncClosureWrapper_VoidResult
        {
            internal static FuncByRef<Closure, TInput0, TInput1, TInput2, TInput3, SValue> _default = Wrapper;
            
            private static SValue Wrapper(ref Closure e, ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2,
                ref TInput3 arg3)
            {
                e.Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
                return SValue.nil;
            }
        }
        

        public bool Equals(FuncClosure<TInput0, TInput1, TInput2, TInput3> other)
        {
            return _context.Equals(other._context) && Equals(_wrapper, other._wrapper);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosure<TInput0, TInput1, TInput2, TInput3> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_context.GetHashCode() * 397) ^ (_wrapper != null ? _wrapper.GetHashCode() : 0);
            }
        }
    }

    public struct FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn> 
        : IEquatable<FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn>>
    {
        private FuncClosure<TInput0, TInput1, TInput2, TInput3> _closure;

        public bool IsValid()
        {
            return _closure.IsValid();
        }
        
        public void Reset()
        {
            _closure.Reset();
        }
        
        public TReturn Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public TReturn Invoke(ref TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg2 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public TReturn InvokeOut(TInput0 arg0, TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public TReturn Invoke(ref TInput0 arg0, TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg2 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, ref TInput1 arg1, TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, out TInput1 arg1, TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg2 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn Invoke(ref TInput0 arg0, ref TInput1 arg1, ref TInput2 arg2, ref TInput3 arg3)
        {
            return _closure.Invoke<TReturn>(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public TReturn InvokeOut(out TInput0 arg0, out TInput1 arg1, out TInput2 arg2, out TInput3 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            arg3 = default;
            return Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }

        public static FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn> Create(
            Func<TInput0, TInput1, TInput2, TInput3, TReturn> func)
        {
            return new FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn>()
            {
                _closure = FuncClosure<TInput0, TInput1, TInput2, TInput3>.Create(func)
            };
        }
        
        public static FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn> Create(
            FuncByRef<TInput0, TInput1, TInput2, TInput3, TReturn> func)
        {
            return new FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn>()
            {
                _closure = FuncClosure<TInput0, TInput1, TInput2, TInput3>.Create(func)
            };
        }
        
        public bool Equals(FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn> other)
        {
            return _closure.Equals(other._closure);
        }

        public override bool Equals(object obj)
        {
            return obj is FuncClosureR<TInput0, TInput1, TInput2, TInput3, TReturn> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _closure.GetHashCode();
        }
    }
}



