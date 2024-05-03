 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PersonUI : MonoBehaviour, IPointerClickHandler
{
    public PersonScriptObject personScript;
    [SerializeField] private UnityEvent<bool> onResetLookPoint;

    public void OnPointerClick(PointerEventData eventData)
    {
        onResetLookPoint.Invoke(false);
    }
}
