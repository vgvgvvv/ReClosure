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

        // 创建Func闭包
        {
            // 通过Func创建闭包FuncClosure，并且捕获了call
            var act = FuncClosure<int>.Create((self, b) => self.Add(b), call);
            // 调用生成的FuncClosure，效果与 (b) => call.Add(b)一致
            var result = act.Invoke<int>(12);
            Assert.AreEqual(result, 22);
        }

        // 创建Action闭包
        {
            // 通过Action创建闭包ActionClosure，并且捕获了call
            var act = ActionClosure<int>.Create((self, b) => self.Add(b), call);
            // 调用生成的ActionClosure，效果与 (b) => call.Add(b)一致
            act.Invoke(12);
        }

        // 通过bind来快速将action转换为闭包，类似于C++中的std::bind
        // 针对Action和Func的用法是一样的
        {
            // 首先创建一个函数
            var func = (TestCall a, int b) => a.Add(b);
            // 然后通过bind来创建闭包
            // (TestCall a, int b) => a.Add(b).Bind(call) 会报错
            var funcBinded = func.Bind(call);
            // 用静态函数也是可以的
            BindHelper.Bind((TestCall a, int b) => a.Add(b), call);
            // 调用生成的闭包
            var result = funcBinded.Invoke<int>(100);
        }

        // 针对对象创建闭包
        // 针对Action和Func的用法是一样的
        {
            // 首先创建一个对象
            var obj = new TestCall(10);
            // 然后通过bind来创建闭包
            var funcBinded = obj.BindSelf((TestCall a, int b) => a.Add(b));
            // 调用生成的闭包, 与obj.Add(100)效果一致
            var result = funcBinded.Invoke<int>(100);
        }

        
    }
    
    
}