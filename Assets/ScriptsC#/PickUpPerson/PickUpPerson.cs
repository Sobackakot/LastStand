 
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData;

    private bool isInitialized = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitialized)
            { 
                isInitialized = true;
                SystemPersonData.Instance?.SetDataPerson(personData); 
            } 
        }
    }
}
