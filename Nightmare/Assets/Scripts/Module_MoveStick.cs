using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UIFramework;

public class Module_MoveStick : UIBase, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    //private void Start()
    //{
    //    bgImg = GetComponent<Image>();
    //    joystickImg = transform.GetChild(0).GetComponent<Image>();
    //}

    public override void InitUIOnAwake()
    {
        this.id = UIID.UIID_JoyStick;
        this.type = UIType.Popup;

        bgImg = GetComponent<Image>();
        bgImg = GameUtility.FindDeepChild<Image>(this.gameObject, "BackgroundImage");
        //joystickImg = transform.GetChild(0).GetComponent<Image>();
        joystickImg = GameUtility.FindDeepChild<Image>(this.gameObject, "JoystickImage");
        if (joystickImg == null)
            Debug.LogError("Can find JoystickImage");
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




    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position,
            eventData.pressEventCamera, out pos))
        {

            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //Move Joystick IMG
            joystickImg.rectTransform.anchoredPosition = new Vector3(
                inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2),
                inputVector.z * (bgImg.rectTransform.sizeDelta.y / 2));

            Debug.Log(inputVector);
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}