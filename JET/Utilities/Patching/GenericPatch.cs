using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JET.Utilities.Patching
{
    public abstract class GenericPatch<T> where T : GenericPatch<T>
    {
        private MethodBase _targetMethod = null;

        public MethodBase TargetMethod 
        { 
            get 
            { 
                if (_targetMethod == null) 
                    _targetMethod = GetTargetMethod(); 
                return _targetMethod; 
            } 
        }

        public MethodInfo Prefix { get; }

        public MethodInfo Postfix { get; }

        public MethodInfo Transpiler { get; }

        public MethodInfo Finalizer { get; }

        protected abstract MethodBase GetTargetMethod();

        public GenericPatch(string prefix = null, string postfix = null, string transpiler = null, string finalizer = null)
        {
            Prefix = GetMethodInfo(prefix);
            Postfix = GetMethodInfo(postfix);
            Transpiler = GetMethodInfo(transpiler);
            Finalizer = GetMethodInfo(finalizer);

            if (Prefix == null && Postfix == null && transpiler == null && finalizer == null)
                throw new Exception("At least one of the patch methods must be specified");
        }

        private MethodInfo GetMethodInfo(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                return null;
            return typeof(T).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }
    }
}
