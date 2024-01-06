namespace ReClosure
{
    public partial struct Closure
    {
    
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
        
        #region Bind1

        public TResult RInvoke<T0, T1, TResult>(T0 arg0)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return func.Invoke(
                    arg0, 
                    SValue.Reader<T1>.Invoke(ref _0)
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }

        public TResult RInvoke<T0, T1, TResult>(T1 arg1)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return func.Invoke(
                    SValue.Reader<T0>.Invoke(ref _0),
                    arg1
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
        
        #endregion
        
        public TResult RInvoke<T0, T1, TResult>(T0 arg0, T1 arg1)
        {
            if(_delegate is Func<T0, T1, TResult> func)
            {
                return func.Invoke(
                    arg0,
                    arg1
                );
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}