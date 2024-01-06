namespace ReClosure;

public static partial class BindHelper
{
	public static ActionClosure Bind<T>(this Action<T> action, T ctx)
	{
		return ActionClosure.Create(action, ctx);
	}
	
	public static ActionClosure Bind<T0, T1>(this Action<T0, T1> action, T0 arg0, T1 arg1)
	{
		return ActionClosure.Create(action, arg0, arg1);
	}
	
	public static ActionClosure Bind<T0, T1, T2>(this Action<T0, T1, T2> action, T0 arg0, T1 arg1, T2 arg2)
	{
		return ActionClosure.Create(action, arg0, arg1, arg2);
	}
	
	public static ActionClosure Bind<T0, T1, T2, T3>(this Action<T0, T1, T2, T3> action, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		return ActionClosure.Create(action, arg0, arg1, arg2, arg3);
	}
	
	public static ActionClosure<TInput0> Bind<TInput0, T>(this Action<T, TInput0> action, T ctx)
	{
		return ActionClosure<TInput0>.Create(action, ctx);
	}
	
	public static ActionClosure<TInput0> Bind<TInput0, T0, T1>(this Action<T0, T1, TInput0> action, T0 arg0, T1 arg1)
	{
		return ActionClosure<TInput0>.Create(action, arg0, arg1);
	}
	
	public static ActionClosure<TInput0> Bind<TInput0, T0, T1, T2>(this Action<T0, T1, T2, TInput0> action, T0 arg0, T1 arg1, T2 arg2)
	{
		return ActionClosure<TInput0>.Create(action, arg0, arg1, arg2);
	}
	
	public static ActionClosure<TInput0, TInput1> Bind<TInput0, TInput1, T>(this Action<T, TInput0, TInput1> action, T ctx)
	{
		return ActionClosure<TInput0, TInput1>.Create(action, ctx);
	}
	
	public static ActionClosure<TInput0, TInput1> Bind<TInput0, TInput1, T0, T1>(this Action<T0, T1, TInput0, TInput1> action, T0 arg0, T1 arg1)
	{
		return ActionClosure<TInput0, TInput1>.Create(action, arg0, arg1);
	}
	
	public static ActionClosure<TInput0, TInput1, TInput2> Bind<TInput0, TInput1, TInput2, T>(this Action<T, TInput0, TInput1, TInput2> action, T ctx)
	{
		return ActionClosure<TInput0, TInput1, TInput2>.Create(action, ctx);
	}

}