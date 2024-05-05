 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData;

    //[Header("Enable and Disable InputContoller")]
    //[SerializeField] private UnityEvent onEnableInputController; // This Event for calss InputController
    //[SerializeField] private UnityEvent onDisableInputController; // This Event for calss InputController

    private bool isInitialized = false;

    [HideInInspector]public string id;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitialized)
            { 
                isInitialized = true;
                SystemPersonData.Instance?.SetDataPerson(personData);
                SystemPersonData.Instance?.AddPersonList(this);
                id = personData.Id;
            } 
        }
    }
}
