 
using UnityEngine;
using UnityEngine.EventSystems; 

public class InventorySlot : MonoBehaviour, IDropHandler   
{ 
    private RectTransform transformSlot; 
    
    private void Awake()
    {   
        transformSlot = GetComponent<RectTransform>();   
    }  
    public void OnDrop(PointerEventData eventData)
    {
        ItemInSlot dropedItem = eventData.pointerDrag.GetComponent<ItemInSlot>();
        if (dropedItem == null) return;
        Transform originalParent = dropedItem.originalParent;
        DropItemInSlot(originalParent, dropedItem); 
    }
    private void DropItemInSlot(Transform originalParent, ItemInSlot dropedItem)
    { 
        // Swap items between the current originalSlot and the dropped item's originalSlot
        if (originalParent != transformSlot)
        {
            // Move the current item (if any) to the dropped item's original originalSlot
            if (transformSlot.childCount > 0)
            {
                Transform currentPoint = transformSlot.GetChild(0);
                currentPoint.SetParent(originalParent);
            }
            // Move the dropped item to the current originalSlot
            dropedItem.originalParent = transformSlot;
        }
    }  
}
