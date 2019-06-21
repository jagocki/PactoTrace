using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PactoTrace
{
    public class Unit : IDisposable
    {
        private string operation;

        private Unit(string operation, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.operation = operation;
            Console.WriteLine($"{operation} Unit Constructor {memberName} {sourceFilePath}:{sourceLineNumber}");
        }


        public void Dispose()
        {
            Console.WriteLine($"{operation} Unit Destructor");

        }

        public static Unit Trace
        {
            get
            {
                return new Unit("Property");
            }
            private set { }
        }

        public void Invoke(Action callbackDelegate)
        {
            callbackDelegate.Invoke();
        }

        public void Invoke<T>(Action<T> callbackDelegate, T arg)
        {
            callbackDelegate.Invoke(arg);
        }

        public TResult Invoke<T, TResult>(Func<T, TResult> callbackDelegate, T arg)
        {
            return callbackDelegate.Invoke(arg);
        }

        public TResult Invoke<T1, T2, TResult>(Func<T1, T2, TResult> callbackDelegate, T1 arg1, T2 arg2)
        {
            return callbackDelegate.Invoke(arg1, arg2);
        }

        public static IDisposable ActivityScope<T1, T2, TResult>(Func<T1, T2, TResult> callbackDelegate, T1 arg1, T2 arg2, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var unit = new Unit("ActivityScope", memberName, sourceFilePath, sourceLineNumber); //Unit.Trace;
            unit.Invoke(callbackDelegate, arg1, arg2);
            return unit;
        }

        public static IDisposable ActivityScope(Action callbackDelegate, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var unit = new Unit("ActivityScope", memberName, sourceFilePath, sourceLineNumber); //Unit.Trace;

            callbackDelegate.Invoke();
            return unit;
        }

        public static void Scope(Action callbackDelegate, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (Unit.ActivityScope(callbackDelegate,memberName, sourceFilePath, sourceLineNumber)) ;

        }

        public static void Scope<T, TResult>(Func<T, TResult> callbackDelegate, T arg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            using (Unit.ActivityScope<T, TResult>(callbackDelegate, arg, memberName, sourceFilePath, sourceLineNumber)) ;

        }

        public static IDisposable ActivityScope<T, TResult>(Func<T, TResult> callbackDelegate, T arg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var unit = new Unit("ActivityScope",memberName, sourceFilePath, sourceLineNumber); //Unit.Trace;
            unit.Invoke(callbackDelegate, arg);
            return unit;
        }

        //public T Invoke<T>(Func<T> callbackDelegate, T arg)
        //{
        //    return callbackDelegate.Invoke();
        //}
        //public TResult Invoke<T1, TResult>(Func<T1, TResult> callbackDelegate, T1 arg)
        //{
        //    //check below
        //    //https://stackoverflow.com/questions/8511466/whats-the-method-signature-for-passing-an-async-delegate
        //    return (TResult)callbackDelegate.Invoke(arg);
        //}

        //public void Invoke(Func<T, T> a)
        //{

        //}

        void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }
    }
}
