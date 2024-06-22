
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public InventoryUI inventoryUi;

    public event Action onUpdateInventorySlots; // Event for InventoryUI
    public event Action<PersonDataScript> onUpdateEquipmentSlot;
    private InventoryPerson inventoryPerson;
    [Header("Inventory Panel UI gameObject")]
    [SerializeField] private GameObject inventoryPanel;

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
    private void OnEnable()
    { 
        InputControlPerson.onActiveInventory += ActiveInventory;
    }

    private void OnDisable()
    { 
        InputControlPerson.onActiveInventory -= ActiveInventory;
    }
    private void ActiveInventory(bool isSwitchActive) // Called from InputControlPerson
    {
        inventoryPanel.SetActive(isSwitchActive); // active inventory Panel 
        if (isSwitchActive)
            onUpdateInventorySlots?.Invoke(); // update inventory for pick person
    } 
    public void GetPersonByInventory(PersonDataScript person) // coll from class CharacterSwitchSystem
    {
        inventoryPerson = person.inventoryPerson; // get pick person for inventory
        onUpdateInventorySlots?.Invoke(); // update inventory slots for new pick person
        onUpdateEquipmentSlot?.Invoke(person); //get person for Equipment slots
    }

    public bool AddItemToInventory(ItemScrObj newItem) //coll from EquipmentController,PickUpItems
    {
        if (inventoryPerson.AddItemToInventory(newItem))
        {
            onUpdateInventorySlots?.Invoke(); // update inventory slots
            return true;
        }
        return false;
    }

    public void RemoveItemFromInventory(ItemScrObj item) // coll from ItemScrObj
    {
        inventoryPerson.RemoveItemFromInventory(item);
        onUpdateInventorySlots?.Invoke(); // update inventory slots
    }

    public void SetItemInSlot(int slotIndex, ItemScrObj newItem) // coll from class InventorySlot
    { 
        inventoryPerson.SetItemInSlot(slotIndex, newItem); // set new slot for item on Drop
    }
    public ItemScrObj GetItemInSlot(int slotIndex)
    { 
        return inventoryPerson.GetItemInSlot(slotIndex);
    }
    public List<ItemScrObj> GetCurrentInventory()
    {
        return inventoryPerson.itemsInventory;
    }
}
