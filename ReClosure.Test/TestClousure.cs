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
        // create a Func closure
        {
            // 通过Func创建闭包FuncClosure，并且捕获了call
            // create a FuncClosure by Func, and capture call
            var act = FuncClosure<int>.Create((self, b) => self.Add(b), call);
            // 调用生成的FuncClosure，效果与 (b) => call.Add(b)一致
            // invoke the closure, same as (b) => call.Add(b)
            var result = act.Invoke<int>(12);
            Assert.AreEqual(result, 22);
        }

        // 创建Action闭包
        // create a Action closure
        {
            // 通过Action创建闭包ActionClosure，并且捕获了call
            // create a ActionClosure by Action, and capture call
            var act = ActionClosure<int>.Create((self, b) => self.Add(b), call);
            // 调用生成的ActionClosure，效果与 (b) => call.Add(b)一致
            // invoke the closure, same as (b) => call.Add(b)
            act.Invoke(12);
        }

        // 通过bind来快速将action转换为闭包，类似于C++中的std::bind
        // create a closure by bind, like std::bind in C++
        // 针对Action和Func的用法是一样的
        // same as Func
        {
            // 首先创建一个函数
            // create a function
            var func = (TestCall a, int b) => a.Add(b);
            // 然后通过bind来创建闭包
            // create a closure by bind
            // (TestCall a, int b) => a.Add(b).Bind(call) 会报错
            // (TestCall a, int b) => a.Add(b).Bind(call) will cause error
            var funcBinded = func.Bind(call);
            // 用静态函数也是可以的
            // static function is ok
            BindHelper.Bind((TestCall a, int b) => a.Add(b), call);
            // 调用生成的闭包
            // invoke the closure
            var result = funcBinded.Invoke<int>(100);
        }

        // 针对对象创建闭包
        // create a closure by object
        // 针对Action和Func的用法是一样的
        // same as Func
        {
            // 首先创建一个对象
            // create a object
            var obj = new TestCall(10);
            // 然后通过bind来创建闭包
            // create a closure by bind
            var funcBinded = obj.BindSelf((TestCall a, int b) => a.Add(b));
            // 调用生成的闭包, 与obj.Add(100)效果一致
            // invoke the closure, same as obj.Add(100)
            var result = funcBinded.Invoke<int>(100);
        }

        
    }
    
    
}