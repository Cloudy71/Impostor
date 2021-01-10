using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace Mod {
    [BepInPlugin("cz.cloudy.mod", "EM Mod", "1.0.0.0")]
    [BepInProcess("Among Us.exe")]
    public class ModPlugin : BasePlugin {
        private void Awake() {
            UnityEngine.Debug.Log("UWU");
        }

        public override void Load() {
            UnityEngine.Debug.Log("UWU");
            Harmony harmony = new Harmony("cz.cloudy.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}