
using System.Collections.Generic; 
using UnityEngine;

public class SystemPersonData : MonoBehaviour
{
    public static SystemPersonData Instance;

    [SerializeField] private List<PickUpPersonUI> personsUI = new List<PickUpPersonUI>(); 

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

    public void SetDataPerson(PersonDataScript dataScript)
    {
        dataScript.Id = "per" + Random.Range(1, 1000000);
        foreach (var uiGroup in personsUI)
        {
            if (!uiGroup.HasData())
            {
                SetActiveUISlot(uiGroup);
                uiGroup.SetDataPersonUI(dataScript);
                break; // Stop after finding the first empty slot
            }
        } 
    }  
        
    private void SetActiveUISlot(PickUpPersonUI uiSlot)
    {
        uiSlot.gameObject.SetActive(true);
    }
}
