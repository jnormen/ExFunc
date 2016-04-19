# ExFunc
This is a framework to group Exceptions. 
Intead of catch each excpetion and have redundant code within them you can with this framework group them and perform actions. 
```javascript
         var a = new Foo();
        
          Do.Try(() => a.ExecuteFoo(3))
                       .Catch<ArgumentException>()
                       .OrCatch<EntryPointNotFoundException>()
                       .OrCatch<ArgumentException>()
                       .ThenReturn((x) => { throw (Exception)x; })
                       .Catch<ArithmeticException>()
                       .ThenReturn((x) => "Hello ArithmeticException")
                       .Run();
```
</code>