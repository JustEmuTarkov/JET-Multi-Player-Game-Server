using System.Reflection;
using UnityEngine;
using EFT;

namespace JET.Utilities.Reflection
{
    internal static class LocalGameUtils
    {
        public static FieldInfo GetFinishCallBack(AbstractGame game)
        {
            FieldInfo callBackField = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "callback_0");

            if (callBackField == null)
            {
                return null;
            }

            return callBackField;
        }

        public static FieldInfo GetCreatePlayerOwnerFunc(AbstractGame game)
        {
            FieldInfo createOwnerFunc = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "func_1");

            if (createOwnerFunc == null)
            {
                return null;
            }

            return createOwnerFunc;
        }

        public static FieldInfo GetCreatePlayerFunc(AbstractGame game)
        {
            FieldInfo createOwnerFunc = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "func_0");

            if (createOwnerFunc == null)
            {
                return null;
            }

            return createOwnerFunc;
        }
    }
}