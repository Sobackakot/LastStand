
using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{ 
    public static EquipmentController Instance;
     
    private InventoryController inventorySystem;
    private EquipmentPerson equipmentPerson;

    public event Action<int> onSetItemByEquipmentSlot;
    public event Action<int> onResetItemByEquipmentSlot;
    public event Action onUpdateEquipmentSlots;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        inventorySystem = InventoryController.Instance;
        inventorySystem.onGetEquipmentPerson += GetPersonByEquipment;
        inventorySystem.onActiveEquipmentPanel += ActiveEquipmentPanel;

    } 

    private void OnDisable()
    {
        inventorySystem.onGetEquipmentPerson -= GetPersonByEquipment;
        inventorySystem.onActiveEquipmentPanel -= ActiveEquipmentPanel;
    }
    private void ActiveEquipmentPanel()
    {
        onUpdateEquipmentSlots?.Invoke();
    }
    private void GetPersonByEquipment(PersonDataScript person) //get a link to the current character. coll from class InvectoryController
    {
        equipmentPerson = person.equipmentPerson;
        onUpdateEquipmentSlots?.Invoke();
    }

    public void EquipItem(EquipmentScrObj newItem) //coll from EquipmentScrObj
    {   
        int slotIndex = 0;
        equipmentPerson.EquipItemOnPerson(out slotIndex,newItem);
        onSetItemByEquipmentSlot?.Invoke(slotIndex);
    }
    private void UnEquipItem(int currentIndex)
    {
        equipmentPerson.UnEquipItemFromPerson(currentIndex);
        onResetItemByEquipmentSlot?.Invoke(currentIndex);
    }
    private void UnEquipItemsAll()
    {
       for(int i = 0; i< equipmentPerson.equipmentItem.Count; i++)
       {
            UnEquipItem(i);
       }
    }
    public List<EquipmentScrObj> GetEquipmentItems()
    {
        return equipmentPerson.GetEquipmentItems();
    }
    private void LateUpdate() //......
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            UnEquipItemsAll();
        }
    }
}
