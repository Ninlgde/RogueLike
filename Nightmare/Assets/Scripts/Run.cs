using UnityEngine;
using System.Collections;
using UIFramework;

public class Run : MonoBehaviour
{

    void Start()
    {
        UIManager.GetInstance().ShowUI(UIID.UIID_Welcome);
        //UIManager.GetInstance().ShowUI(UIID.UIID_JoyStick);
    }
}
