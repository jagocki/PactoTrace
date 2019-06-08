using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PactoTraceNet.ExtensionMethods
{
    public static class Extensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static T TraceMe<T>( this Func<T> method)
        {
            return method.Invoke();
        }

        public static void TraceMe(this object method)
        {
            //return method.Invoke();
        }

        //public static int GetMaxLength<TSource, TProperty>(this TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        //   where TSource : class, new()
        //   where TProperty : IComparable, ICloneable, IConvertible, IComparable<string>, IEnumerable<char>, IEnumerable, IEquatable<string>
        //{
        //    PropertyInfo propInfo = source.GetPropertyInfo(propertyLambda);
        //    MaxlengthAttribute attrMaxLength = propInfo.GetCustomAttributes(typeof(MaxlengthAttribute), false).FirstOrDefault() as MaxlengthAttribute;
        //    return attrMaxLength != null ? attrMaxLength.MaxLength : 0;
        //}


        public static void TraceMySource<TSource>(this Expression<Func<TSource>> source)
           //where TSource : class, new()
        {
            
        }
    }
}
