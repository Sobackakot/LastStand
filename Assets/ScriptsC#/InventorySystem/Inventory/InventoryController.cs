
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController: IInitializable, IDisposable
{   
    public event Action onPointerExit;

    private EquipmentController equipment;
    private IInventoryUI<int> inventoryUI;
    private GameObject panel;


    private InventoryPerson inventoryPerson;
    private EquipmentPerson equipmentPerson;
     
    public InventoryController([Inject(Id = "inventoryUI")] IInventoryUI<int> inventoryUI,
        EquipmentController equipment,  [Inject(Id = "inventoryPanel")] GameObject panel)
    {
        this.inventoryUI = inventoryUI;
        this.equipment = equipment;
        this.panel = panel; 
    }

    public void Initialize()
    {
        InputControlPerson.onActiveInventory += ActiveInventory; 
        inventoryUI.onSetNewItem += GetCurrentInventory;
    }
    public void Dispose()
    {
        InputControlPerson.onActiveInventory -= ActiveInventory;
        equipmentPerson.onEquipItemOnPerson -= AddItemToInventory;
        inventoryUI.onSetNewItem -= GetCurrentInventory;
    } 
    private void ActiveInventory(bool isSwitchActive) // Called from InputControlPerson
    {
        panel.SetActive(isSwitchActive); // active inventory Panel  
        if (isSwitchActive)
        {
            inventoryUI.UpdateInventorySlots(); // update inventory for pick person
            equipment.ActiveEquipmentPanel();
        }  
        else onPointerExit?.Invoke();// если инвентарь деактивирован то включаем возможность выделять рамкой
    }
    public void GetPersonByInventory(PersonDataScript person) // coll from class CharacterSwitchSystem
    {
        inventoryPerson = person.inventoryPerson; // get pick person for inventory
        equipmentPerson = person.equipmentPerson;
        equipmentPerson.onEquipItemOnPerson += AddItemToInventory;
        equipment.GetPersonByEquipment(person); //get person for EquipmentScrObj slots
        inventoryUI.UpdateInventorySlots(); // update inventory slots for new pick person 
    }
     

    public bool AddItemToInventory(ItemScrObj newItem) //coll from EquipmentController,PickUpItems
    {
        int slotIndex = 0;
        if (inventoryPerson.AddItemToInventory(out slotIndex,newItem))
        {
            inventoryUI.SetNewItemByInventoryCell(slotIndex); // update inventory slots
            return true;
        }
        return false;
    }

    public void RemoveItemFromInventory(ItemScrObj item) // coll from ItemInSlot
    {
        int slotIndex = 0; 
        inventoryPerson.RemoveItemFromInventory(out slotIndex,item);
        inventoryUI.ResetItemByInventoryCell(slotIndex);// update inventory slots
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
