using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ClickObject : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        //    throw new NotImplementedException();
        Debug.Log("Click " + eventData.pointerPress);
    }
}
