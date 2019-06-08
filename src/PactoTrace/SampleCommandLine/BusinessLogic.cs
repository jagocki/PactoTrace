using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommandLine
{
    class BusinessLogic
    {
        public void DoSomeWork()
        {
            Console.WriteLine("doing some work");
        }

        public void DoSomeWork(int arg)
        {
            Console.WriteLine($"doing some int work with {arg} and returning void");

        }

        public int DoSomeWorkInt()
        {
            Console.WriteLine("doing some int work");
            return 0;
        }
        public int DoSomeWorkInt(int param)
        {
            Console.WriteLine($"doing some int work with {param}");
            return param;
        }


        public int DoSomeWorkIntInt(int param1, int param2)
        {
            Console.WriteLine($"doing some int work with {param1} and with {param2}");
            return param1 + param2 ;
        }
    }
}
