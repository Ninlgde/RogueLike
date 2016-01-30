using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UIFramework;

public class Win_Welcome : UIBase
{
    private Button btn_startGame;

    public override void InitUIOnAwake()
    {
        this.id = UIID.UIID_Welcome;
        this.type = UIType.Normal;

        btn_startGame = GameUtility.FindDeepChild(this.gameObject, "btn_empty").gameObject.GetComponent<Button>();
        btn_startGame.onClick.AddListener(
            delegate ()
            {
                this.StartGame();
            }
            );
    }

    public override void ShowUI()
    {
        base.ShowUI();
        Debug.Log("Win_Welcome . ShowUI");
    }

    public override void HideUI()
    {
        base.HideUI();
    }

    public override void DestroyUI()
    {
        base.DestroyUI();
    }

    private void StartGame()
    {
        NewSceneManager.GetInstance().LoadScene("SafeRoom");
        this.DestroyUI();
    }
}
