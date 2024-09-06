
using System;
using System.Collections.Generic; 
using Zenject;

public class EquipmentController  : IInitializable, IDisposable
{   
    private IInventoryUI<int> equipmentUI;

    private EquipmentPerson equipment;

    public EquipmentController([Inject(Id = "equipmentUI")] IInventoryUI<int> equipmentUI)
    {
        this.equipmentUI = equipmentUI;
    }
    public void Initialize()
    {
        equipmentUI.onSetNewItem += GetEquipmentItems;
    } 
    public void Dispose()
    {
        equipmentUI.onSetNewItem -= GetEquipmentItems;
    }
    public void ActiveEquipmentPanel()
    {
        equipmentUI.UpdateInventorySlots();
    }
    public void GetPersonByEquipment(PersonDataScript person) //get a link to the current character. coll from class InvectoryController
    {
        equipment = person.equipmentPerson;
        equipmentUI.UpdateInventorySlots();
    }

    public void EquipItem(ItemScrObj newItem) //coll from ItemInSlot
    {   
        int slotIndex = 0;
        equipment.EquipItemOnPerson(out slotIndex,newItem);
        equipmentUI.SetNewItemByInventoryCell(slotIndex); 
    }
    public List<ItemScrObj> GetEquipmentItems()
    {
        return equipment.GetEquipmentItems();
    }
    private void UnEquipItem(int currentIndex)
    {
        equipment.UnEquipItemFromPerson(currentIndex); 
        equipmentUI.ResetItemByInventoryCell(currentIndex);
    }
    private void UnEquipItemsAll() //....
    {
       for(int i = 0; i< equipment.equipmentItem.Count; i++)
       {
            UnEquipItem(i);
       }
    }

}
