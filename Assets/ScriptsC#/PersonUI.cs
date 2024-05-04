 
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PersonUI : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private Image perImage;
    [SerializeField] private TextMeshProUGUI namePerson;
    [SerializeField] private PersonDataScript personDataUI;
    private bool hasData = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Clicked character with ID: " + personDataUI.Id);
            Debug.Log("Character Name: " + personDataUI.Name);
        }
    }

    public void SelectPersonData(PersonDataScript data)
    {
        personDataUI = data;
        UpdateUI();
        hasData = true;
    }

    private void UpdateUI()
    {
        perImage.sprite = personDataUI.sprite;
        namePerson.text = personDataUI.Name;
    }

    public bool HasData()
    {
        return hasData;
    }
}
