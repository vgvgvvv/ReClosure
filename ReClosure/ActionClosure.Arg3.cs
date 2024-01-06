namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2>
    {
        private Closure _closure;
        private Action<Closure, TInput0, TInput1, TInput2> _wrapper;

        public void Reset()
        {
            _wrapper = null;
            _closure.Reset();
        }

        public void Invoke(TInput0 arg, TInput1 arg1, TInput2 arg3)
        {
            if (_wrapper != null) 
                _wrapper(_closure, arg, arg1, arg3);
        }

        public static ActionClosure<TInput0, TInput1, TInput2> Create(Action<TInput0, TInput1, TInput2> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _closure = new Closure { _delegate = action },
                _wrapper = (c, arg0, arg1, arg2) => c.Invoke(arg0, arg1, arg2)
            };
        }

        public static ActionClosure<TInput0, TInput1, TInput2> Create<T>(Action<T, TInput0, TInput1, TInput2> action, T ctx)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2>
            {
                _closure = new Closure
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

    }
}
