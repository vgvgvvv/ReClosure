namespace ReClosure
{
    public struct ActionClosure<TInput0, TInput1, TInput2, TInput3>
    {
        private Closure _closure;
        private Action<Closure, TInput0, TInput1, TInput2, TInput3> _wrapper;

        public void Reset()
        {
            _wrapper = null;
            _closure.Reset();
        }

        public void Invoke(TInput0 arg, TInput1 arg1, TInput2 arg3, TInput3 arg4)
        {
            if (_wrapper != null) 
                _wrapper(_closure, arg, arg1, arg3, arg4);
        }

        public static ActionClosure<TInput0, TInput1, TInput2, TInput3> Create(Action<TInput0, TInput1, TInput2, TInput3> action)
        {
            Closure.Check(action);
            return new ActionClosure<TInput0, TInput1, TInput2, TInput3>
            {
                _closure = new Closure { _delegate = action },
                _wrapper = (c, arg0, arg1, arg2, arg3) => c.Invoke(arg0, arg1, arg2, arg3)
            };
        }

    }
}
