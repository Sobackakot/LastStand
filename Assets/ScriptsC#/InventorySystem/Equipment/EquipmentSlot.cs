

using UnityEngine.EventSystems;

public class EquipmentSlot : InventorySlot
{
    public override void AddItemInSlot(ItemInSlot item, ItemScrObj data)
    {
        base.AddItemInSlot(item, data);
    }
    public override void RemoveItemInSlot(ItemInSlot item)
    {
        base.RemoveItemInSlot(item);
    }
    public override void OnDrop(PointerEventData eventData)
    { 
        base.OnDrop(eventData);
    }
}
