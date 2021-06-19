using System.Linq;
using System.Reflection;

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
            MethodInfo[] methods = obj.GetType().GetMethods(PrivateValueAccessor.Flags);
            return methods.FirstOrDefault(methodInfo => methodInfo.Name == methodName);
        }
    }
}