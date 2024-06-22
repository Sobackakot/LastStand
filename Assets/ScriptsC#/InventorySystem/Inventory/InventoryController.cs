
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public InventoryUI inventoryUi;

    public event Action onUpdateInventoryPerson;
    public event Action<int> onResetItemByInventoryCell;
    public event Action<int> onSetNewItemByInventoryCell; // Event for InventoryUI
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
            onUpdateInventoryPerson?.Invoke(); // update inventory for pick person
    }
    public void GetPersonByInventory(PersonDataScript person) // coll from class CharacterSwitchSystem
    {
        inventoryPerson = person.inventoryPerson; // get pick person for inventory
        onUpdateInventoryPerson?.Invoke(); // update inventory slots for new pick person
        onUpdateEquipmentSlot?.Invoke(person); //get person for Equipment slots
    }

    public bool AddItemToInventory(ItemScrObj newItem) //coll from EquipmentController,PickUpItems
    {
        int slotIndex = 0;
        if (inventoryPerson.AddItemToInventory(out slotIndex,newItem))
        {
            onSetNewItemByInventoryCell?.Invoke(slotIndex); // update inventory slots
            return true;
        }
        return false;
    }

    public void RemoveItemFromInventory(ItemScrObj item) // coll from ItemScrObj
    {
        int slotIndex = 0; 
        inventoryPerson.RemoveItemFromInventory(out slotIndex,item);
        onResetItemByInventoryCell?.Invoke(slotIndex);// update inventory slots
    }

    public void SwapItemInSlot(int slotIndex, ItemScrObj newItem) // coll from class InventorySlot
    { 
        inventoryPerson.SwapItemInSlot(slotIndex, newItem); // set new slot for item on Drop  
    } 
    public List<ItemScrObj> GetCurrentInventory()
    {
        return inventoryPerson.itemsInventory;
    }
}
