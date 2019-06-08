using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PactoTraceNet
{
    public class Unit : IDisposable
    {
        private Unit([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {

            Console.WriteLine($"Unit Constructor {memberName} {sourceFilePath}:{sourceLineNumber}");
        }


        public void Dispose()
        {
        }

        public static Unit Trace
        {
            get
            {
                return new Unit();
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

        public T Invoke<T>(Func<T> callbackDelegate)
        {
            return callbackDelegate.Invoke();
        }
        public TResult Invoke<T1, TResult>(Func<T1, TResult> callbackDelegate, T1 arg)
        {
            //check below
            //https://stackoverflow.com/questions/8511466/whats-the-method-signature-for-passing-an-async-delegate
            return (TResult)callbackDelegate.Invoke(arg);
        }

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
