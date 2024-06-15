
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance; 

    public event Action onUpdateInventorySlots; // Event for InventoryUI
    public event Action<PersonDataScript> onUpdateEquipmentSlot;
    private InventoryPerson inventoryPerson;


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
    public void UpdateInventory()
    {
        onUpdateInventorySlots?.Invoke();
    }
    public void SetPersonInventory(PersonDataScript person)
    {
        inventoryPerson = person.inventoryPerson;
        onUpdateInventorySlots?.Invoke(); 
        onUpdateEquipmentSlot?.Invoke(person);
    }

    public bool AddItemToInventory(ItemScrObj newItem) //coll from EquipmentController
    {
        if (inventoryPerson.AddItemToInventory(newItem))
        {
            onUpdateInventorySlots?.Invoke(); 
            return true;
        }
        return false;
    }

    public void RemoveItemFromInventory(ItemScrObj item) // coll from ItemScrObj
    {
        inventoryPerson.RemoveItemFromInventory(item);
        onUpdateInventorySlots?.Invoke();
    }
    public List<ItemScrObj> GetCurrentInventory()
    {
        return inventoryPerson.itemsInventory;
    }
}
