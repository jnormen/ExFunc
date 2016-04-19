using System;
using ExFunk;

namespace ExFuncConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
         var a = new Foo();
        
          Do.Try(() => a.ExecuteFoo(3))
                       .Catch<ArgumentException>()
                       .OrCatch<EntryPointNotFoundException>()
                       .OrCatch<ArgumentException>()
                       .ThenReturn((x) => { throw (Exception)x; })
                       .Catch<ArithmeticException>()
                       .ThenReturn((x) => "Hello ArithmeticException")
                       .Run();

            //    Console.WriteLine(result);
          

            Console.ReadLine();
        }
    }

    class Foo
    {
        public void ExecuteFoo(int a)
        {
	        if (a == 1) return;
	        else if (a == 2) throw new ArithmeticException("...");
	        else if (a == 3) throw new EntryPointNotFoundException("...");
	        else throw new ArgumentException("...");
        }
    }
}
