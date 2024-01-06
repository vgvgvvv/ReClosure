namespace ReClosure.Test;

internal class TestCall
{
    public TestCall(int inA)
    {
        a = inA;
    }
    public int Add(int b)
    {
        return a + b;
    }

    private int a = 0;
}

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        TestCall call = new TestCall(10);
        var act = FuncClosure<int>.Create((self, b) => self.Add(b), call);
        var result = act.Invoke<int>(12);
        Assert.AreEqual(result, 22);
    }
}