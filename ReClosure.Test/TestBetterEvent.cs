namespace ReClosure.Test;

[TestFixture]
public class TestBetterEvent
{
	private BetterEvent<int> Event = new BetterEvent<int>();
	private ClosureEvent<int> ClosureEvent = new ClosureEvent<int>();

	[Test]
	public void TestBetterEventBoardcast()
	{
		int b = 122;
		ClosureEvent += ActionClosure<int>.Create(
			(arg1, arg2) =>
			{
				Console.WriteLine($"I got a {arg1 + arg2}");
			}, b);
		
		ClosureEvent.Invoke(100);
	}
}