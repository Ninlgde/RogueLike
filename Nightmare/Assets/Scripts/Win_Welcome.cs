using UnityEngine;
using System.Collections;
using UIFramework;

public class Win_Welcome : UIBase
{
    public override void InitUIOnAwake()
    {
        this.id = UIID.UIID_Welcome;
        this.type = UIType.Normal;
    }

    public override void ShowUI()
    {
        base.ShowUI();
        Debug.Log("Win_Welcome . ShowUI");
    }
}
