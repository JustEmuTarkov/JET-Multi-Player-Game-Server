using System;
using System.Linq;
using System.Reflection;

namespace JET.Utilities.Reflection
{
    public static class PrivateValueAccessor
    {
        public const BindingFlags Flags = BindingFlags.GetProperty
                                        | BindingFlags.SetProperty
                                        | BindingFlags.GetField
                                        | BindingFlags.SetField
                                        | BindingFlags.NonPublic
                                        | BindingFlags.Public
                                        | BindingFlags.FlattenHierarchy
                                        | BindingFlags.IgnoreCase;

        public static PropertyInfo GetPrivatePropertyInfo(Type type, string propertyName)
        {
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | Flags);
            return props.FirstOrDefault(propInfo => propInfo.Name == propertyName);
        }

        public static PropertyInfo GetStaticPropertyInfo(Type type, string propertyName)
        {
            PropertyInfo[] props = type.GetProperties(BindingFlags.Static | Flags);
            return props.FirstOrDefault(propInfo => propInfo.Name == propertyName);
        }

        public static object GetStaticPropertyValue(Type type, string propertyName)
        {
            return GetStaticPropertyInfo(type, propertyName).GetValue(null);
        }

        public static object GetPrivatePropertyValue(Type type, string propertyName, object o)
        {
            return GetPrivatePropertyInfo(type, propertyName).GetValue(o);
        }

        public static FieldInfo GetPrivateFieldInfo(Type type, string fieldName)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | Flags);
            return fields.FirstOrDefault(fieldInfo => fieldInfo.Name == fieldName);
        }

        public static object GetPrivateFieldValue(Type type, string fieldName, object o)
        {
            return GetPrivateFieldInfo(type, fieldName).GetValue(o);
        }

        public static void SetPrivateFieldValue(Type type, string fieldName, object o, object value)
        {
            GetPrivateFieldInfo(type, fieldName).SetValue(o, value);
        }
    }
}