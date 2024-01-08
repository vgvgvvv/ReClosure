# ReClosure
yet another non-gc closure library

# Usage
```C#
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
```

```C#
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
```