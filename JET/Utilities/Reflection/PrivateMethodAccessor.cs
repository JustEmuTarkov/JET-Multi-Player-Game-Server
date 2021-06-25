using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JET.Utilities.Reflection
{
    public class PrivateMethodAccessor
    {
        /// <summary>
        /// A static method to get the FieldInfo of a private field of any object.
        /// </summary>
        /// <param name="obj">The object that has the private method</param>
        /// <param name="methodName">The name of the private method</param>
        /// <returns>MethodInfo object. It has the method name and a useful Invoke() method.</returns>
        public static MethodInfo GetPrivateMethodInfo(object obj, string methodName)
        {
            MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            return methods.FirstOrDefault(methodInfo => methodInfo.Name == methodName);
        }

        /// <summary>
        /// A static method to get the FieldInfo of a private field of any object.
        /// </summary>
        /// <param name="type">The type that has the private method</param>
        /// <param name="methodName">The name of the private method</param>
        /// <returns>MethodInfo object. It has the method name and a useful Invoke() method.</returns>
        public static MethodInfo GetPrivateMethodInfoByType(Type type, string methodName)
        {
            MethodInfo[] methods = type.GetMethods(PrivateValueAccessor.Flags);
            return methods.FirstOrDefault(methodInfo => methodInfo.Name == methodName);
        }

        public static MethodInfo GetPrivateMethodByType(Type type, string methodName)
        {
            return type.GetTypeInfo().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static MethodInfo GetPrivateStaticMethodByType(Type type, string methodName)
        {
            return type.GetTypeInfo().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
        }

        public static MethodInfo GetPrivateStaticGenericMethodByType<T>(Type type, string methodName)
        {
            return type.GetTypeInfo().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(typeof(T));
        }
    }
}