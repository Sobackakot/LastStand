
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public static event Action <bool> onPointerEnterUI; // event for class PersonMoveControl,SelectPersonsSystem 
    public void OnPointerEnter(PointerEventData eventData) 
    {
        onPointerEnterUI?.Invoke(true);//checks the position of the mouse cursor on ui elements
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        onPointerEnterUI?.Invoke(false);//checks the position of the mouse cursor on ui elements
    } 
}
