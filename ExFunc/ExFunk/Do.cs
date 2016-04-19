using System;

namespace ExFunk
{
    public class Do
    {
        public static Catcher Try(Func<dynamic> x)
        {
            return new Catcher(x);
        }

        public static Catcher Try(Action x)
        {
            return new Catcher(x);
        }
    }
}






