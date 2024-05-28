
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [HideInInspector] public bool isPointerEnterUI; 
    public static event Action <bool> onPointerEnterUI;
    public void OnPointerEnter(PointerEventData eventData)
    { 
        isPointerEnterUI = true;
        Debug.Log(isPointerEnterUI);
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerEnterUI = false;
        Debug.Log(isPointerEnterUI);
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }
}
