using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData;
    public List<PersonUI> personsUI = new List<PersonUI>();

    private bool isInitialized = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitialized)
            { 
                personData.Id = "per" + Random.Range(1, 1000000); 
                isInitialized = true;
            }

            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        foreach (var uiGroup in personsUI)
        {
            if (!uiGroup.HasData())
            {
                uiGroup.SelectPersonData(personData);
                break; // Stop after finding the first empty slot
            }
        }
    }
}
