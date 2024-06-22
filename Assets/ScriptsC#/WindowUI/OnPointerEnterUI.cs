
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public static event Action <bool> onPointerEnterUI;
    private bool isPointer = false;
    public void OnPointerEnter(PointerEventData eventData) //checks the position of the mouse cursor on ui elements
    {
        onPointerEnterUI?.Invoke(true);
        isPointer = true;
    }

    public void OnPointerExit(PointerEventData eventData) //checks the position of the mouse cursor on ui elements
    {
        onPointerEnterUI?.Invoke(false);
        isPointer = false;
    } 
}
