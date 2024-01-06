//#define CHECK_CLOSURE

using System.Diagnostics;

namespace ReClosure;

public struct Closure
{
    public SValue _0;
    public SValue _1;
    public SValue _2;
    public SValue _3;
    public Delegate _delegate;

    public T ctx_0<T>()
    {
        return SValue.Reader<T>.Invoke(ref _0);
    }

    public T ctx_1<T>()
    {
        return SValue.Reader<T>.Invoke(ref _1);
    }

    public T ctx_2<T>()
    {
        return SValue.Reader<T>.Invoke(ref _2);
    }

    public T ctx_3<T>()
    {
        return SValue.Reader<T>.Invoke(ref _3);
    }

    public void Reset()
    {
        _delegate = null;
        _0 = SValue.nil;
        _1 = SValue.nil;
        _2 = SValue.nil;
        _3 = SValue.nil;
    }

    public void Invoke()
    {
        if (_delegate is Action act)
        {
            act();
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public void Invoke<T>()
    {
        if (_delegate is Action<T> act)
        {
            act(SValue.Reader<T>.Invoke(ref _0));
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public void Invoke<T0, T1>()
    {
        if(_delegate is Action<T0, T1> act)
        {
            act(SValue.Reader<T0>.Invoke(ref _0), SValue.Reader<T1>.Invoke(ref _1));
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public void Invoke<T0, T1, T2>()
    {
        if (_delegate is Action<T0, T1, T2> act)
        {
            act.Invoke(
                SValue.Reader<T0>.Invoke(ref _0), 
                SValue.Reader<T1>.Invoke(ref _1),
                SValue.Reader<T2>.Invoke(ref _2)
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public void Invoke<T0, T1, T2, T3>()
    {
        if(_delegate is Action<T0, T1, T2, T3> act)
        {
            act.Invoke(
                SValue.Reader<T0>.Invoke(ref _0), 
                SValue.Reader<T1>.Invoke(ref _1),
                SValue.Reader<T2>.Invoke(ref _2), 
                SValue.Reader<T3>.Invoke(ref _3)
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public TResult RInvoke<TResult>()
    {
        if(_delegate is Func<TResult> func)
        {
            return func.Invoke();
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public TResult RInvoke<T, TResult>()
    {
        if(_delegate is Func<T, TResult> func)
        {
            return func.Invoke(SValue.Reader<T>.Invoke(ref _0));
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public TResult RInvoke<T0, T1, TResult>()
    {
        if(_delegate is Func<T0, T1, TResult> func)
        {
            return func.Invoke(
                SValue.Reader<T0>.Invoke(ref _0), 
                SValue.Reader<T1>.Invoke(ref _1)
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public TResult RInvoke<T0, T1, T2, TResult>()
    {
        if(_delegate is Func<T0, T1, T2, TResult> func)
        {
            return func.Invoke(
                SValue.Reader<T0>.Invoke(ref _0), 
                SValue.Reader<T1>.Invoke(ref _1),
                SValue.Reader<T2>.Invoke(ref _2)
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public TResult RInvoke<T0, T1, T2, T3, TResult>()
    {
        if(_delegate is Func<T0, T1, T2, T3, TResult> func)
        {
            return func.Invoke(
                SValue.Reader<T0>.Invoke(ref _0), 
                SValue.Reader<T1>.Invoke(ref _1),
                SValue.Reader<T2>.Invoke(ref _2), 
                SValue.Reader<T3>.Invoke(ref _3)
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public SValue SRInvoke<TResult>()
    {
        if(_delegate is Func<TResult> func)
        {
            return SValue.Writer<TResult>.Invoke(func.Invoke());
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public SValue SRInvoke<T, TResult>()
    {
        if(_delegate is Func<T, TResult> func)
        {
            return SValue.Writer<TResult>.Invoke(func.Invoke(SValue.Reader<T>.Invoke(ref _0)));
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public SValue SRInvoke<T0, T1, TResult>()
    {
        if(_delegate is Func<T0, T1, TResult> func)
        {
            return SValue.Writer<TResult>.Invoke(
                func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1)
                )
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public SValue SRInvoke<T0, T1, T2, TResult>()
    {
        if(_delegate is Func<T0, T1, T2, TResult> func)
        {
            return SValue.Writer<TResult>.Invoke(
                func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    SValue.Reader<T2>.Invoke(ref _2)
                )
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    public SValue SRInvoke<T0, T1, T2, T3, TResult>()
    {
        if(_delegate is Func<T0, T1, T2, T3, TResult> func)
        {
            return SValue.Writer<TResult>.Invoke(
                func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0), 
                    SValue.Reader<T1>.Invoke(ref _1),
                    SValue.Reader<T2>.Invoke(ref _2), 
                    SValue.Reader<T3>.Invoke(ref _3)
                )
            );
        }
        else
        {
            throw new Exception("Invalid closure");
        }
    }

    [Conditional("DEBUG")]
    public static void Check(object d)
    {
        if (((Delegate)d).Target == null)
        {
            throw new Exception("Invoke invalid closure");
        }
    }
}

public struct ActionClosure
{
    private Closure _closure;
    private Action<Closure> _wrapper;

    public void Reset()
    {
        _wrapper = null;
        _closure.Reset();
    }

    public void Invoke()
    {
        if (_wrapper != null) _wrapper(_closure);
    }

    public static ActionClosure Create(Action action)
    {
        Closure.Check(action);
        return new ActionClosure
        {
            _closure = new Closure { _delegate = action },
            _wrapper = e => e.Invoke()
        };
    }

    public static ActionClosure Create<T>(Action<T> action, T ctx)
    {
        Closure.Check(action);
        return new ActionClosure
        {
            _closure = new Closure
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
            _closure = new Closure
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
            _closure = new Closure
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
            _closure = new Closure
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
}

public struct FuncClosure
{
    private Closure _context;
    private Func<Closure, SValue> _wrapper;

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
//EOF