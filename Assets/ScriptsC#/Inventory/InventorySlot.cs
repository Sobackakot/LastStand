
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ItemScrObj itemScrObj;
     
    private RectTransform transformSlot;
    private Transform transformItem;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    
     
    private void Awake()
    { 
        transformSlot = GetComponent<RectTransform>();
        transformItem = transformSlot.GetChild(0).GetComponent<Transform>();
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = itemIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemAmount = itemIcon.transform.GetChild(1).GetComponent<TextMeshProUGUI>(); 
    } 
    public void AddItemToSlot(ItemScrObj newItem) // coll from InventotyUI
    {   
        itemScrObj = newItem; 
        itemName.text = itemScrObj.NameItem;
        itemAmount.text = itemScrObj.item.itemAmount.ToString();
        itemIcon.sprite = itemScrObj.IconItem;
        itemIcon.enabled = true; 
    }
    public void CleareSlot() // coll from InventotyUI
    {
        itemScrObj = null; 
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " ";
    }

    public void CheckCurrentItemInSlot()
    {
        if (itemScrObj != null && itemScrObj.item.itemAmount < 1)
        {
            CleareSlot(); 
        } 
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragAndDropItem droppedItem = eventData.pointerDrag.GetComponent<DragAndDropItem>();
        Transform formerPosition = droppedItem.originalParent;
        if(formerPosition!=transformSlot)
        {
            droppedItem.originalParent = transformSlot;
            droppedItem.transform.SetParent(transformSlot);
        } 
        if (transformSlot.childCount == 0)
        {
            transformItem.SetParent(transformSlot);
        }
        else transformItem.SetParent(formerPosition);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         
    }
}
