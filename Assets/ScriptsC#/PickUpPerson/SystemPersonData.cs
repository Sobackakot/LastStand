 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemPersonData : MonoBehaviour
{
    public static SystemPersonData Instance;

    [SerializeField] private List<PickUpPersonUI> personsUI = new List<PickUpPersonUI>();
    [SerializeField] private List<PickUpPerson> personsObj = new List<PickUpPerson>();
    public UnityEvent<bool, PickUpPerson> onSetFocusCamera; // This Event for calss CameraLookTarget

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void AddPersonList(PickUpPerson personObj) // Add new person my group
    {
        personsObj.Add(personObj);
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data person 
    {
        dataScript.Id = "per" + Random.Range(1, 1000000);
        foreach (var uiGroup in personsUI)
        {
            if (!uiGroup.HasData())
            {
                ActivePersonUI(uiGroup);
                uiGroup.SetDataPersonUI(dataScript);
                break; // Stop after finding the first empty slot
            }
        } 
    }
    public void SetFocusCamera(string id) //set focus camera pickup person
    {
        foreach (PickUpPerson pers in personsObj)
        {
            if (pers.id == id)
            {
                onSetFocusCamera.Invoke(false, pers); // ResetLookPoint
            }
        }
    }
    private void ActivePersonUI(PickUpPersonUI uiSlot) //Active new person my ui slot group
    {
        uiSlot.gameObject.SetActive(true);
    } 
    
}
