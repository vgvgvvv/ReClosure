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
		{
			int b = 122;
			ClosureEvent += ActionClosure<int>.Create(
				// 注意绑定项永远在前面，输入项在后面
				// 所以在这里第一个是绑定项，第二个是输入项
				// 实在搞不清也可以看一下Create的签名，输入项是TInput0，绑定项是T
				(arg1, arg2) =>
				{
					Console.WriteLine($"I got a {arg1 + arg2}");
				}, b);
			
			// ClosureEvent.Invoke(100);
			// 输出 I got a 222
		}

		// 比较常见的绑定对象
		{
			// 创建对象
			TestCall call = new TestCall();
			// 注意绑定项永远在前面，输入项在后面，故第一个就是self
			ClosureEvent += ActionClosure<int>.Create(
				(self, a) => self.OnCall(a), 
				call);
		}

		// 快速绑定对象
		{
			// 创建对象
			TestCall call = new TestCall();
			// BindSelf, 后面传入的闭包中第一项就是自己
			ClosureEvent += call.BindSelf((TestCall self, int a) =>
			{
				self.OnCall(a);
			});
		}
		
		// 当然想用Bind也是可以的
		{
			// 创建对象
			TestCall call = new TestCall();
			// BindSelf, 后面传入的闭包中第一项就是自己
			ClosureEvent += BindHelper.Bind((TestCall self, int a) =>
			{
				self.OnCall(a);
			}, call);

			var lamb = (int a, int b) => Console.WriteLine(a + b);
			// 注意 永远绑前面的，所以a == 100, b则是Invoke输入的值
			ClosureEvent += lamb.Bind(100);
		}
		
		// 触发所有绑定函数
		ClosureEvent.Invoke(100);
	}
}