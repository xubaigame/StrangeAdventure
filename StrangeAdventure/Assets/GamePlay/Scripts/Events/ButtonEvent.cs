using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public UnityEvent clickDown;
    public UnityEvent clickUp;

    public void OnPointerUp(PointerEventData eventData)
    {
        clickUp?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickDown?.Invoke();
    }
}
