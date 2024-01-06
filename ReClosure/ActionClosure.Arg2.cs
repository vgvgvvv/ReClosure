namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1>
    {
        private Closure _closure;
        private Action<Closure, TInput0, TInput1> _wrapper;

        public void Reset()
        {
            _wrapper = null;
            _closure.Reset();
        }

        public void Invoke(TInput0 arg, TInput1 arg1)
        {
            if (_wrapper != null) 
                _wrapper(_closure, arg, arg1);
        }

        public static ActionClosure<TInput0, TInput1> Create(Action<TInput0, TInput1> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1>
            {
                _closure = new Closure { _delegate = action },
                _wrapper = (c, arg0, arg1) => c.Invoke(arg0, arg1)
            };
        }

        public static ActionClosure<TInput0, TInput1> Create<T>(Action<T, TInput0, TInput1> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1>
            {
                _closure = new Closure
                {
                    _0 = SValue.Writer<T>.Invoke(ctx),
                    _delegate = action
                },
                _wrapper = ActionClosureWrapper<T>._default
            };
        }

        public static ActionClosure<TInput0, TInput1> Create<T0, T1>(Action<T0, T1, TInput0, TInput1> action, T0 ctx0, T1 ctx1)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1>
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

    
        internal class ActionClosureWrapper<T>
        {
            internal static Action<Closure, TInput0, TInput1> _default = (e, arg0, arg1) => e.Invoke<T, TInput0, TInput1>(arg0, arg1);
        }

        internal class ActionClosureWrapper<T0, T1>
        {
            internal static Action<Closure, TInput0, TInput1> _default = (e, arg0, arg1) => e.Invoke<T0, T1, TInput0, TInput1>(arg0, arg1);
        }
        
    }
}
