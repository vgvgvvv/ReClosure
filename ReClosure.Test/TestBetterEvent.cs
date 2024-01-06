namespace ReClosure.Test;

[TestFixture]
public class TestBetterEvent
{
	private BetterEvent<int> Event = new BetterEvent<int>();
	private ClosureEvent<int> ClosureEvent = new ClosureEvent<int>();

	class TestCall
	{
		public int OnCall(int a)
		{
			return a;
		}
	}

	[Test]
	public void TestBetterEventBoardcast()
	{
		int b = 122;
		ClosureEvent += ActionClosure<int>.Create(
			(arg1, arg2) =>
			{
				Console.WriteLine($"I got a {arg1 + arg2}");
			}, b);

		TestCall call = new TestCall();
		ClosureEvent += ActionClosure<int>.Create(
			(self, a) => self.OnCall(a), 
			call);

		ClosureEvent += call.BindSelf((TestCall self, int a) =>
		{
			self.OnCall(a);
		});
		
		ClosureEvent.Invoke(100);
	}
}