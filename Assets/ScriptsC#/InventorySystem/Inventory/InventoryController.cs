
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    public event Action onUpdateInventoryPerson; // event for class InventoryUI
    public event Action<int> onResetItemByInventoryCell;// event for class InventoryUI
    public event Action<int> onSetNewItemByInventoryCell; // event for class InventoryUI
    public event Action<PersonDataScript> onGetEquipmentPerson; // event for class EquipmentController
    public event Action onActiveEquipmentPanel;// event for class EquipmentController

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
        {
            onUpdateInventoryPerson?.Invoke(); // update inventory for pick person
            onActiveEquipmentPanel?.Invoke();   
        }  
    }
    public void GetPersonByInventory(PersonDataScript person) // coll from class CharacterSwitchSystem
    {
        inventoryPerson = person.inventoryPerson; // get pick person for inventory
        onGetEquipmentPerson?.Invoke(person); //get person for EquipmentScrObj slots
        onUpdateInventoryPerson?.Invoke(); // update inventory slots for new pick person 
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
    public List<ItemScrObj> GetCurrentInventory() //get a list of items from a character's inventory
    {
        return inventoryPerson.itemsInventory;
    }
}
