# Constants

References
- [Constants on Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants)


## Remarks
- Constants 는 컴파일 시점에 결정되는 immutable(불변) values 이다.
- 오직 C# built-in type(excluding System.Ojbect) 에 대해서만 사용이 가능하다.
- 실행 시점에 딱 한 번만 초기화(such as Constructor)가 필요한 class, struct 또는 array를 생성할 때는 ```readonly``` 를 사용해야 한다.
- C# 은 ```const``` methods, properties 또는 evetns 를 지원하지 않는다.

```
! NOTE !
특정 DLL 에 정의되어 있는 constant 를 사용할 때는 주의해야 한다.
해당 constant 를 새로운 값으로 업데이트하여 DLL 이 새롭게 변경되더라도 기존 그것을 참조하던 프로그램에서는 여전히 예전 값을 가지고 있을 수 있다. 이런 경우, 해당 프로그램도 새롭게 recompile 되어야 한다. 
```
=> constant 는 compile 시점에 결정이 되고 그것을 참조하는 IL 코드에 해당 literal을 그대로 삽입한다. 반면에 readonly 는 변수로서 관리가 되고, IL 코드에 직접적으로 쓰지 않고 run time 시에 해당 값을 읽어온다. 생각으로는,,, constant 가 private, internal, private protected 로 선언이 되어 있을 경우는 문제가 없지만, 같은 assembly 가 아닌 곳에서 사용될 수 있는 access modifier 로 선언되어 있는 경우는 주의해야 한다.