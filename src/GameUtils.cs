using System.Collections.Generic;
using UnityEngine;

namespace GHLime
{
    public class GameUtils
    {
        public static void UnlockMap()
        {
            var mapTab = MapTab.Get();
            if (mapTab == null || mapTab.m_MapDatas.Count == 0 ) 
            {
                Debug.LogError(string.Format("{0}: Map could not be unlocked", Mod.modInstance.name));
                return; 
            }

            foreach (var map in mapTab.m_MapDatas) 
            { 
                if (map.Value.m_Unlocked) { continue; }

                mapTab.UnlockPage(map.Key);
                foreach (var mapElement in map.Value.m_Elemets)
                {
                    MapUtils.UnlockElement(mapTab.m_MapDatas, mapElement.name);
                }
            }
        }
    }

    public class MapUtils
    {
        public static void UnlockElement(Dictionary<string, MapPageData> mapData, string elementName)
        {
            foreach (string key in mapData.Keys)
            {
                for (int i = 0; i < mapData[key].m_Elemets.Count; i++)
                {
                    if (mapData[key].m_Elemets[i].name == elementName)
                    {
                        if (!mapData[key].m_Elemets[i].activeSelf)
                        {
                            MenuNotepad.Get().OnAddMapArea();
                        }

                        mapData[key].m_Elemets[i].SetActive(true);
                        ReplicatedNotepad.OnUnlockMapElement(elementName);
                        break;
                    }
                }
            }
        }
    }
}