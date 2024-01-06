namespace ReClosure
{
    public partial struct Closure
    {
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
        
        public void Invoke<T>(T arg0)
        {
            if (_delegate is Action<T> act)
            {
                act(arg0);
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }   
    }
}