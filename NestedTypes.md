# Nested Types

References
- [Nested Types on Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/nested-types)
<br>
<br>

```class```, ```struct``` 또는 ```interface``` 내부에 새롭게 정의된 타입을 nested type이라고 한다.

```c#
public class Container
{
    class Nested
    {
        Nested() { }
    }
}
```
<br>

nested type을 정의한 outer 가 class, interface 또는 struct 상관없이 기본적으로 ```private``` access modifier를 갖게 되고, 해당 타입을 정의한 type(their containing type) 에서만 access가 가능하다.<br>

Nested type은 아래와 같은 Access modifier 를 가질 수 있다.

1. class의 nested type은 ```public```, ```protected```, ```internal```, ```protected internal```, ```private```, ```private protected```로 선언이 가능하다. <br>
하지만 ```sealed class``` 내부에서 ```protected```, ```protected internal```, ```private protected```로 선언하면 compile warning ```CS0628```를 생성한다.
1. struct의 nested type은 ```public```, ```internal```, ```private``` 가 될 수 있다. 
<br>
<br>

nested type 은 containing type (또는 outer) 에 access 가능하다. 
```c#
public class Container
{
    public class Nested
    {
        private Container parent;

        public Nested()
        {
        }
        public Nested(Container parent)
        {
            this.parent = parent;
        }
    }
}
```
<br>

Nested type 은 containing type 의 모든 member 에 access가 가능하다. ```private```, ```protected``` 멤버 뿐만이 아니라 상속받은 ```protected``` 멤버도 가능하다. <br>

아래처럼 instance를 생성할 수 있다. 
```c#
Container.Nested nest = new Container.Nested();
```