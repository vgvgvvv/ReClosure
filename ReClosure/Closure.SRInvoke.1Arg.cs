namespace ReClosure;

public partial struct Closure
{
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
}