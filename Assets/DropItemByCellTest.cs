
using UnityEngine;
using UnityEngine.EventSystems;


//Script from new Scena !!!!!
public class DropItemByCellTest : MonoBehaviour, IDropHandler
{
    private Transform cellTransform;
    private void Awake()
    {
        cellTransform = GetComponent<Transform>();  
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemDrugByGridTest droppedItem = eventData.pointerDrag.GetComponent<ItemDrugByGridTest>();
        if (droppedItem == null)
            return;

        Transform droppedItemOriginalParent = droppedItem.currentTransform;

        // Swap items between the current slot and the dropped item's slot
        if (droppedItemOriginalParent != cellTransform)
        {
            // Move the current item (if any) to the dropped item's original slot
            if (cellTransform.childCount > 0)
            {
                Transform currentItem = cellTransform.GetChild(0);
                currentItem.SetParent(droppedItemOriginalParent);
            }

            // Move the dropped item to the current slot
            droppedItem.currentTransform = cellTransform;
        }
    } 
}
