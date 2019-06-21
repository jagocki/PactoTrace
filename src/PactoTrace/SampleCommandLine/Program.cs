using PactoTrace;
using PactoTrace.ExtensionMethods;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var u = Unit.Trace)
            {
                Console.WriteLine("inside using");
                var logic = new BusinessLogic();
                u.Invoke(logic.DoSomeWork);
                int result = u.Invoke<int,int>(logic.DoSomeWorkInt,1);
                Console.WriteLine($"result:{result}");

                Func<int, int> f = delegate (int a)
                {
                    return logic.DoSomeWorkInt(a);
                };

                result = u.Invoke<int, int>(delegate (int a)
                 {
                     int z = 4;
                     int b = 7;
                     int c = z + b;
                     return logic.DoSomeWorkInt(a + c)
                     ;
                 }, result);


                result = u.Invoke<int, int>(f, result);

                using (Unit.ActivityScope(() => {
                    u.Invoke<int, int>((x) => logic.DoSomeWorkInt(x), result);

                    u.Invoke<int, int, int>((x, y) => logic.DoSomeWorkIntInt(x, y), 1, 2);

                    result = u.Invoke<int, int, int>(logic.DoSomeWorkIntInt, 1, 2);
                })) ;


                Unit.Scope(() => {
                    u.Invoke<int, int>((x) => logic.DoSomeWorkInt(x), result);

                    u.Invoke<int, int, int>((x, y) => logic.DoSomeWorkIntInt(x, y), 1, 2);

                    result = u.Invoke<int, int, int>(logic.DoSomeWorkIntInt, 1, 2);
                }) ;


                //http://www.extensionmethod.net/2117/csharp/func/get-maxlength-attribute-from-property-of-an-class
                //http://geekswithblogs.net/mrsteve/archive/2012/02/19/a-fast-c-sharp-extension-method-using-expression-trees-create-instance-from-type-again.aspx
                Console.WriteLine($"result:{result}");

                using (Unit.ActivityScope((x) => logic.DoSomeWorkInt(x), result)) ;
                Unit.Scope((x) => logic.DoSomeWorkInt(x), result) ;

                using (Unit.ActivityScope(logic.DoSomeWorkInt,1)) ;

                using (Unit.ActivityScope(logic.DoSomeWorkIntInt, 1, 13)) ;

            }
        }
    }
}
