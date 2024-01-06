using System;

namespace ReClosure
{
	public static partial class BindHelper
	{
		public static FuncClosure Bind<TResult>(this Func<TResult> func)
		{
			return FuncClosure.Create<TResult>(func);
		}
		
		public static FuncClosure Bind<T, TResult>(this Func<T, TResult> func, T ctx)
		{
			return FuncClosure.Create<T, TResult>(func, ctx);
		}
		
		public static FuncClosure Bind<T0, T1, TResult>(this Func<T0, T1, TResult> func, T0 arg0, T1 arg1)
		{
			return FuncClosure.Create<T0, T1, TResult>(func, arg0, arg1);
		}
		
		public static FuncClosure Bind<T0, T1, T2, TResult>(this Func<T0, T1, T2, TResult> func, T0 arg0, T1 arg1, T2 arg2)
		{
			return FuncClosure.Create<T0, T1, T2, TResult>(func, arg0, arg1, arg2);
		}
		
		public static FuncClosure Bind<T0, T1, T2, T3, TResult>(this Func<T0, T1, T2, T3, TResult> func, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			return FuncClosure.Create<T0, T1, T2, T3, TResult>(func, arg0, arg1, arg2, arg3);
		}
		
		public static FuncClosure<TInput0> Bind<TInput0, TResult>(this Func<TInput0, TResult> func)
		{
			return FuncClosure<TInput0>.Create<TResult>(func);
		}
		
		public static FuncClosure<TInput0> Bind<TInput0, T, TResult>(this Func<T, TInput0, TResult> func, T ctx)
		{
			return FuncClosure<TInput0>.Create<T, TResult>(func, ctx);
		}
		
		public static FuncClosure<TInput0> Bind<TInput0, T0, T1, TResult>(this Func<T0, T1, TInput0, TResult> func, T0 arg0, T1 arg1)
		{
			return FuncClosure<TInput0>.Create<T0, T1, TResult>(func, arg0, arg1);
		}
		
		public static FuncClosure<TInput0> Bind<TInput0, T0, T1, T2, TResult>(this Func<T0, T1, T2, TInput0, TResult> func, T0 arg0, T1 arg1, T2 arg2)
		{
			return FuncClosure<TInput0>.Create<T0, T1, T2, TResult>(func, arg0, arg1, arg2);
		}
		
		public static FuncClosure<TInput0, TInput1> Bind<TInput0, TInput1, TResult>(this Func<TInput0, TInput1, TResult> func)
		{
			return FuncClosure<TInput0, TInput1>.Create<TResult>(func);
		}
		
		public static FuncClosure<TInput0, TInput1> Bind<TInput0, TInput1, T, TResult>(this Func<T, TInput0, TInput1, TResult> func, T ctx)
		{
			return FuncClosure<TInput0, TInput1>.Create<T, TResult>(func, ctx);
		}
		
		public static FuncClosure<TInput0, TInput1> Bind<TInput0, TInput1, T0, T1, TResult>(this Func<T0, T1, TInput0, TInput1, TResult> func, T0 arg0, T1 arg1)
		{
			return FuncClosure<TInput0, TInput1>.Create<T0, T1, TResult>(func, arg0, arg1);
		}
		
		public static FuncClosure<TInput0, TInput1, TInput2> Bind<TInput0, TInput1, TInput2, TResult>(this Func<TInput0, TInput1, TInput2, TResult> func)
		{
			return FuncClosure<TInput0, TInput1, TInput2>.Create<TResult>(func);
		}
		
		public static FuncClosure<TInput0, TInput1, TInput2> Bind<TInput0, TInput1, TInput2, T, TResult>(this Func<T, TInput0, TInput1, TInput2, TResult> func, T ctx)
		{
			return FuncClosure<TInput0, TInput1, TInput2>.Create<T, TResult>(func, ctx);
		}
		
		public static FuncClosure<TInput0, TInput1, TInput2, TInput3> Bind<TInput0, TInput1, TInput2, TInput3, TResult>(this Func<TInput0, TInput1, TInput2, TInput3, TResult> func)
		{
			return FuncClosure<TInput0, TInput1, TInput2, TInput3>.Create<TResult>(func);
		}
		
		public static FuncClosure BindSelf<TSelf, TResult>(this TSelf self, Func<TSelf, TResult> action)
		{
			return FuncClosure.Create(action, self);
		}
		
		public static FuncClosure<T0> BindSelf<TSelf, T0, TResult>(this TSelf self, Func<TSelf, T0, TResult> action)
		{
			return FuncClosure<T0>.Create(action, self);
		}

		public static FuncClosure<T0, T1> BindSelf<TSelf, T0, T1, TResult>(this TSelf self, Func<TSelf, T0, T1, TResult> action)
		{
			return FuncClosure<T0, T1>.Create(action, self);
		}
		
		public static FuncClosure<T0, T1, T2> BindSelf<TSelf, T0, T1, T2, TResult>(this TSelf self, Func<TSelf, T0, T1, T2, TResult> action)
		{
			return FuncClosure<T0, T1, T2>.Create(action, self);
		}
		
	}
}

