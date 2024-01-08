namespace ReClosure.Test;

[TestFixture]
public class TestBetterEvent
{
	class TestCall
	{
		public int OnCall(int a)
		{
			return a;
		}
	}

	private ClosureEvent<int> ClosureEvent = new ClosureEvent<int>();

	[Test]
	public void TestBetterEventBoardcast()
	{

		ClosureEvent += (a) => { };

		// 直接通过lambda创建闭包
		// create a closure by lambda 
		{
			int b = 122;
			ClosureEvent += ActionClosure<int>.Create(
				// 注意绑定项永远在前面，输入项在后面
				// bind item is always in front, input item is in the back
				// 所以在这里第一个是绑定项，第二个是输入项
				// so the first one is bind item, the second one is input item
				// 实在搞不清也可以看一下Create的签名，输入项是TInput0，绑定项是T
				// if you are confused, you can check the signature of Create, input item is TInput0, bind item is T
				(arg1, arg2) =>
				{
					Console.WriteLine($"I got a {arg1 + arg2}");
				}, b);
			
			// ClosureEvent.Invoke(100);
			// 输出 I got a 222
			// output I got a 222
		}

		// 比较常见的绑定对象
		// create a closure by bind object
		{
			// 创建对象
			// create a object
			TestCall call = new TestCall();
			// 注意绑定项永远在前面，输入项在后面，故第一个就是self
			// bind item is always in front, input item is in the back, so the first one is self
			ClosureEvent += ActionClosure<int>.Create(
				(self, a) => self.OnCall(a), 
				call);
		}

		// 快速绑定对象
		// bind object quickly
		{
			// 创建对象
			TestCall call = new TestCall();
			// BindSelf, 后面传入的闭包中第一项就是自己
			// BindSelf, the first item in the closure is self
			ClosureEvent += call.BindSelf((TestCall self, int a) =>
			{
				self.OnCall(a);
			});
		}
		
		// 当然想用Bind也是可以的
		// bind is ok
		{
			// 创建对象
			// create a object
			TestCall call = new TestCall();
			// BindSelf, 后面传入的闭包中第一项就是自己
			// BindSelf, the first item in the closure is self
			ClosureEvent += BindHelper.Bind((TestCall self, int a) =>
			{
				self.OnCall(a);
			}, call);

			var lamb = (int a, int b) => Console.WriteLine(a + b);
			// 注意 永远绑前面的，所以a == 100, b则是Invoke输入的值
			// bind item is always in front, so a == 100, b is the input value
			ClosureEvent += lamb.Bind(100);
		}
		
		// 触发所有绑定函数
		// invoke all closures
		ClosureEvent.Invoke(100);
	}
}