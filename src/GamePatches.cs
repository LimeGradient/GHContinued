using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace GHLime
{
    [HarmonyPatch]
    public class Patch_WeaponController
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(WeaponController), "Hit")]
        private void MyHit(CJObject cj_object, Collider coll, Vector3 hit_pos, Vector3 hit_dir)
        {
            if (coll.tag == "Player")
                return;
        }
    }
}
