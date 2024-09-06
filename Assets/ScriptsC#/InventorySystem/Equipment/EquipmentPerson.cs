
using System;
using System.Collections.Generic; 

public class EquipmentPerson 
{
    public readonly List<ItemScrObj> equipmentItem;

    public event Func<ItemScrObj, bool> onEquipItemOnPerson;

    public EquipmentPerson()
    {       
        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length; //get the number of slots for equipmentUI items
        equipmentItem = new List<ItemScrObj>(indexSlot);
        for(int i =0; i< indexSlot; i++)
        {
            equipmentItem.Add(null); //initialize item equipmentUI slots
        }
    }
    public void EquipItemOnPerson(out int slotIndex, ItemScrObj newItem) // coll from class EquipmentController
    {
        int currentIndex = (int)newItem.IndexOfSlot; // convert from EquipmentScrObj Slot to index 
        ItemScrObj oldItem = null;
        if (equipmentItem[currentIndex] != null) //if such an item is already equipped
        {
            oldItem = equipmentItem[currentIndex]; //return the item back to inventory
            onEquipItemOnPerson?.Invoke(oldItem);
        }
        slotIndex = currentIndex;
        equipmentItem[currentIndex] = newItem;//equip pick item  from inventory cell
    }
    public void UnEquipItemFromPerson(int currentIndex) // coll from class EquipmentController
    {
        if (equipmentItem[currentIndex] != null)//if such an item is already equipped
        {
            ItemScrObj oldItem = equipmentItem[currentIndex];//return the item back to inventory
            onEquipItemOnPerson?.Invoke(oldItem);
            equipmentItem[currentIndex] = null;//reset an item's equipmentUI slot 
        }
    }
    public List<ItemScrObj> GetEquipmentItems() // coll from class EquipmentController
    {
        return equipmentItem;
    }
}
