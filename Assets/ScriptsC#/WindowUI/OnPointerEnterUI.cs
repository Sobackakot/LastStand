
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public bool isPointerEnterUI; 
    public static event Action <bool> onPointerEnterUI;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerEnterUI = true;
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerEnterUI = false;
        onPointerEnterUI?.Invoke(isPointerEnterUI);
    }
}
