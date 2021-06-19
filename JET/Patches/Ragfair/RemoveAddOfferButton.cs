using System.Reflection;
using EFT.UI;
using EFT.UI.Matchmaker;
using JET.Utilities.Patching;
using UnityEngine;

namespace JET.Patches.Ragfair
{
    class RemoveAddOfferButton_Awake : GenericPatch<RemoveAddOfferButton_Awake>
    {
        public RemoveAddOfferButton_Awake() : base(postfix: nameof(PatchPostfix))
        {
        }

        public static void PatchPostfix(ref DefaultUIButton ____addOfferButton)
        {
            //____addOfferButton.gameObject.SetActive(false);
            ____addOfferButton.Interactable = false;
            ____addOfferButton.OnClick.RemoveAllListeners();
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(EFT.UI.Ragfair.RagfairScreen).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
    class RemoveAddOfferButton_Call : GenericPatch<RemoveAddOfferButton_Call>
    {
        public RemoveAddOfferButton_Call() : base(postfix: nameof(PatchPostfix))
        {
        }

        public static void PatchPostfix(ref DefaultUIButton ____addOfferButton)
        {
            //____addOfferButton.gameObject.SetActive(false);
            ____addOfferButton.Interactable = false;
            ____addOfferButton.OnClick.RemoveAllListeners(); // just incase
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(EFT.UI.Ragfair.RagfairScreen).GetMethod("method_6", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}
