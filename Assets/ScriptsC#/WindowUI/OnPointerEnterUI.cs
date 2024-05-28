
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [HideInInspector] public bool isPointerEnterUI; 
    public static event Action <bool> onPointerEnterUI;
    public void OnPointerEnter(PointerEventData eventData) //checks the position of the mouse cursor on ui elements
    { 
        isPointerEnterUI = true; 
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }

    public void OnPointerExit(PointerEventData eventData) //checks the position of the mouse cursor on ui elements
    {
        isPointerEnterUI = false; 
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }
}
