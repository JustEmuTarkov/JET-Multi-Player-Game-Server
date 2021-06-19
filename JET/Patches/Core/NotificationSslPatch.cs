using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.Networking;
using HarmonyLib;
using JET.Utilities.Patching;

namespace JET.Patches
{
    public class NotificationSslPatch : GenericPatch<NotificationSslPatch>
    {
        private string _MethodName = "get_UriParams";
        private string _MethodName_MoveNext = "MoveNext";
        private static string _certificateHandler = "set_certificateHandler";
        public NotificationSslPatch() : base(transpiler: nameof(PatchTranspiler)){}

        protected override MethodBase GetTargetMethod()
        {
            //return PatcherConstants.TargetAssembly
            //    .GetTypes().Single(x => x.GetMethod(_MethodName, BindingFlags.Public | BindingFlags.Instance) != null)
            //    .GetNestedTypes(BindingFlags.NonPublic).Single(y => y.GetConstructor(new[] { typeof(int)}) != null)
            //    .GetMethod(_MethodName_MoveNext, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return PatcherConstants.TargetAssembly.GetTypes().First(x =>
                    x.IsClass &&
                    x.GetMethod(_MethodName, BindingFlags.Public | BindingFlags.Instance) != null)
                .GetNestedTypes(BindingFlags.NonPublic)
                .Single(y => y.GetConstructor(new[] { typeof(int) }) != null).GetMethod(_MethodName_MoveNext,
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }
        #region Info
        /* what's going on here?

           GClass1182 has a nested class that is an IEnumerator. In its MoveNext method, there is a particular bit of code that creates
           a UnityWebRequest for a notification poll request. We want this to use a specific certificateHandler that we've already patched
           to always validate, but it uses the default cerficateHandler (set to null) whose validation will fail for JET.
           So we patch this in.

           There is this little bit of code in the else statement:
               this.int_0 = -1;
               this.string_0 = gclass.method_1();
               this.unityWebRequest_0 = new UnityWebRequest(this.string_0, "GET");
               this.int_0 = -3;
               this.unityWebRequest_0.downloadHandler = new DownloadHandlerBuffer();
               if (gclass.dictionary_1 != null)
               {
               ...

           We want to add a little initializer to the third line so that it looks like this:
                this.unityWebRequest_0 = new UnityWebRequest(this.string_0, "GET")
                {
                    certificateHandler = new CertificateHandler()
                };

            As stated before, this CertificateHandler we've constructed has its ValidateCertificate method patched in SslCertificatePatch,
            so this should allow our notification requests to always be validated.

            For posterity, I'm also including the ILCode transformation here:
            ID  OFF     OpCode  Operand
            124	016F	ldarg.0
            125	0170	ldarg.0
            126	0171	ldfld	string GClass1182/Class1034::string_0
            127	0176	ldstr	"GET"
            128	017B	newobj	instance void [UnityEngine.UnityWebRequestModule]UnityEngine.Networking.UnityWebRequest::.ctor(string, string)
           *129	0180	dup
           *130	0181	newobj	instance void [UnityEngine.UnityWebRequestModule]UnityEngine.Networking.CertificateHandler::.ctor()
           *131	0186	callvirt	instance void [UnityEngine.UnityWebRequestModule]UnityEngine.Networking.UnityWebRequest::set_certificateHandler(class [UnityEngine.UnityWebRequestModule]UnityEngine.Networking.CertificateHandler)
            132	018B	stfld	class [UnityEngine.UnityWebRequestModule]UnityEngine.Networking.UnityWebRequest GClass1182/Class1034::unityWebRequest_0

            The codes prefixed by the asterisks (*) are the ones patched-in.

        */
        #endregion
        static IEnumerable<CodeInstruction> PatchTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var index = 0;

            for (var i = 0; i < codes.Count(); i++)
            {
                if (codes[i].ToString().Contains("UnityEngine.Networking.UnityWebRequest::.ctor"))
                {
                    index = i + 1;
                    break;
                }
            }

            if (index == 0)
            {
                index = 139;
            }

            var dupCode = new CodeInstruction(OpCodes.Dup);

            var certificateHandlerType = PatcherConstants.TargetAssembly.GetTypes().Single(x => x.BaseType == typeof(CertificateHandler));
            var newObjCode = new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(certificateHandlerType));
            var callVirtCode = new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(UnityWebRequest), _certificateHandler));

            var insertCodes = new List<CodeInstruction>()
            {
                dupCode,
                newObjCode,
                callVirtCode
            };
            codes.InsertRange(index, insertCodes);

            return codes.AsEnumerable();
        }
    }
}
