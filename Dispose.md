# Dispose
References:
- 시작하세요! C# 9.0


때에 따라서 unmanaged memory 를 할당하여 사용해야 하는데, 이 경우 managed heap 을 쓰는 것이 아니라서 GC가 자동으로 memroy 를 해제하지 못한다. 사용자가 직접 해당 memory 를 해제해야 한다. <br>

그러한 목적으로 IDisposable interface 를 상속받도록 하여 Dispose method 를 통해 메로리 해제를 구현하도록 한 것이다. <br>

Example
```c#
class MyClass : IDisposable
{
    public MyClass()
    {
        // Allocate unmanaged memory
    }

    public void Dispose()
    {
        // Release unmanaged memory
    }
}
```

외부에서 해당 클래스를 생성하고 사용한 뒤에는 Dispose 를 호출해야 한다.

```c#
var myClass = new MyClass();

// Do something

myClass.Dispose();

```

하지만 Dispose가 호출이 되기도 전에 exception 이 발생하게 되면 메모리가 정상적으로 해제가 돼지 못하게 된다. 그러한 상황을 방지하기 아래와 같이 try/finally 를 사용한다. 

```c#
try
{
    var myClass = new MyClass();
    // Do something
}
finally
{
    myClass.Dispose();
}
```

또는 아래와 같이 using 을 사용하여 simple 하게 작성한다. 

```c#
using (var myClass = new MyClass())
{
    // Do something
}
```