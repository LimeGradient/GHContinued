using HarmonyLib;
using UnityEngine;

namespace GHLime
{
    public class GHContinued : Mod
    {
        bool isMapUnlocked = false;
        GreenHellGame gameInstance;
        public void Start()
        {
            Debug.Log("Mod GHContinued has been loaded!");
            gameInstance = GreenHellGame.Instance;

            var harmony = new Harmony("limegradient.ghcontinued");
            harmony.PatchAll();
        }

        public void Update()
        {
            if (GHAPI.IsCurrentSceneGame())
            {
                if (!isMapUnlocked && gameInstance.m_GameMode == Enums.GameMode.Survival) 
                {
                    GameUtils.UnlockMap();
                    isMapUnlocked = true;
                }
            }
        }

        public void OnModUnload()
        {
            Debug.Log("Mod GHContinued has been unloaded!");
        }
    }
}