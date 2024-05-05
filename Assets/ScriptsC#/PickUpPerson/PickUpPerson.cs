 
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData;

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
