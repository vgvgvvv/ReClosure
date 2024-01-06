namespace ReClosure
{
    public partial struct Closure
    {
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
    }
}