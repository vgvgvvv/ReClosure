namespace ReClosure;

public partial struct Closure
{
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
}