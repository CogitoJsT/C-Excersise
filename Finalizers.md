
# Finalizers 
References
- [Finalizers in Microsoft docuemnt](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/finalizers)  
- 시작하세요! C# 9.0 프로그래밍

<br>
GC가 class instance 를 수집할 때 꼭 필요한 final cleanup 작업을 하기 위해 호출된다.  <br>
=> calss 를 만든 개발자가 해당 클래스를 사용하는 개발자의 실수를 예상하고 방어적인 차원에서 자원 해제 코드를 넣어 두는 곳
<br><br>

## Remarks
- class 에서만 정의
- 오직 하나
- 상속되거나 overloading 불가
- 의도적으로 호출 불가능, 자동으로 호출됨
- modifier 나 매개변수 없음

#
1. finalizer 는 아래와 같이 선언한다.
   ```c#
   class Car
   {
        ~Car() // finalizer
        {
            // cleanup statements...
        }
   }
   ```
2. finalizer 는 내부적으로 base class의 Finalize를 호출 => base class 에 Finalize 를 무조건 선언해야 하나?

    ```c#
    protected override void Finalize()
    {
        try
        {
            // Cleanup statements...
        }
        finally
        {
            base.Finalize();
        }
    }
    ```
3. empty finalizers는 사용하지 말아야 한다. class 에 finalizers가 선언되어 있으면 ```Finalize``` queue 에 entry 가 만들어진다. 이 queue 는 GC 에 의해 처리되는데, GC가 해당 queue 를 처리할 때 base class 각각의 finalizer 를 호출한다. 불필요한 finalizer 가 있으면 그만큼 불필요하게 performance 를 낭비하는 것이다. 

1. 프로그래머는 finalizer 의 호출 시점을 컨트롤 할 수 없다. GC 만이 호출 시점을 결정한다. GC는 해당 객체가 application에 의해 더이상 사용이 되지 않는 확인하고, finalization 할 조건이 되면 finalizer를 호출한다.  
강제로 GC 가 ```Collect``` 를 호출하도록 할 수 있지만 대개의 경우 performance 이슈로 인해 피하는 것이 좋다.

    ```
    ! Note !
    application이 종료될 때, finalizer 의 동작 여부는 .NET 의 구현에 따라 다르다.  

    -  .NET framework :  
        application 이 종료될 때, cleanup 작업을 일부러 막아놓은 상태가 아니라면 아직 garbage collect 되지 못한 객체들의 finalizer 를 호출한다. 

    - .NET 5 : 
        application 종료 시점에 finalizer를 호출하지 않는다.

    ```

1. 만약 application 종료될 때 cleanup 이 동작하도록 해야 한다면, ```System.AppDomain.ProcessExit``` 이벤트의 handler 를 등록해야 한다.  

- handler 는 application 이 종료되기 전에 cleanup이 필요한 모든 객체들을 위한 ```IDisposable.Dispose()``` 가 호출이 되었는지 확인해야 한다. 프로그래머는 직접적으로 ```Finalize``` 를 호출할 수 없고, 종료 전에 GC가 모든 finalizer를 호출했는지에 대한 보증이 없기 때문.  
- 그런 이유로, 반드시 ```Dispose``` or ```DisposeAsync``` 를 수행하여 resources 를 정상적으로 해제해야 한다.