namespace ReClosure
{
	public partial struct Closure
	{
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
	}
}