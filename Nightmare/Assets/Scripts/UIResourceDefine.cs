using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UIFramework
{
    public enum UIID
    {
        UIID_Invaild = 0,
        UIID_Welcome
    }

    public enum UIType
    {
        Normal,
        Popup,
        Mask
    }

    public class UIResourceDefine
    {
        public static Dictionary<UIID, string> UIPrefabPath = new Dictionary<UIID, string>()
        {
            {UIID.UIID_Welcome,"Win_Welcome" }
        };

        public static string UIPrefabPathString = "UIPrefabs/";
    }
}
