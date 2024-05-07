
using System;
using System.Collections.Generic;
using UnityEngine; 

public class SystemPersonData : MonoBehaviour
{
    public static SystemPersonData Instance;

    [Header("List person UI and current amoutn PickUpPerson")]
    [SerializeField] private List<PickUpPersonUI> personsUI = new List<PickUpPersonUI>(30);
    [SerializeField] private List<PickUpPerson> personsObjs = new List<PickUpPerson>(30);
    
    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget  
      
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
        personsObjs.Add(personObj);
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data person 
    {
        dataScript.Id = "per" + UnityEngine.Random.Range(1, 1000000);
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
        foreach (PickUpPerson pers in personsObjs)
        {
            if (pers.id == id)
            { 
                onResetFocusCamera?.Invoke(false, pers); // ResetLookPoint 
                break;
            } 
        }
    } 
    private void ActivePersonUI(PickUpPersonUI uiSlot) //Active new person my ui slot group
    {
        uiSlot.gameObject.SetActive(true);
    } 

}
