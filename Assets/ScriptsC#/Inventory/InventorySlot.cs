
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour,IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryContoller inventorySystem;
    private ItemScrObj dataItem;
     
    private RectTransform transformSlot;
    private Transform transformItem;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    
    private bool isDraggingItem = false;

    private void Awake()
    { 
        transformSlot = GetComponent<RectTransform>();
        transformItem = transformSlot.GetChild(0).GetComponent<Transform>();
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = itemIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemAmount = itemIcon.transform.GetChild(1).GetComponent<TextMeshProUGUI>(); 
    }
    private void Start()
    {
        inventorySystem = InventoryContoller.Instance;
    }
    private void LateUpdate()
    {   
        if(isDraggingItem)
            inventorySystem.currentItem.OnDragItem();
    }
    public void AddItemToSlot(ItemScrObj newItem) // coll from InventotyUI
    {   
        if(newItem == null) return;
        dataItem = newItem; 
        itemName.text = dataItem.NameItem;
        itemAmount.text = dataItem.item.itemAmount.ToString();
        itemIcon.sprite = dataItem.IconItem;
        itemIcon.enabled = true; 
    }
    public void CleareSlot() // coll from InventotyUI
    {
        dataItem = null; 
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " ";
    }

    public void CheckCurrentItemInSlot()
    {
        if (dataItem != null && dataItem.item.itemAmount < 1)
        {
            CleareSlot(); 
        } 
    } 

    public void OnPointerDown(PointerEventData eventData)
    {
        if (dataItem == null) return;
        inventorySystem.currentItem.OnPointerDownItem();
        inventorySystem.currentItem.PickUpItemInSlot(dataItem);
        inventorySystem.currentItem.OnBeginDragItem();
        CleareSlot();
        Debug.Log("PointerDownSlot"); 
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inventorySystem.currentItem.OnPointerUpItem();
        inventorySystem.currentItem.OnEndDragItem();
        if (dataItem == null)
        {
            inventorySystem.currentItem.DropItemInSlot(out dataItem);
            AddItemToSlot(dataItem);
            Debug.Log("Drop");
        }
        Debug.Log("PointerUpSlot");
    }

    
     
    public void OnPointerEnter(PointerEventData eventData)
    {
        isDraggingItem = inventorySystem.currentItem.IsDragging();
        if (isDraggingItem) return;
        inventorySystem.currentItem.UpdatePointEnter(transformSlot);
        Debug.Log("PointerEntert");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         
    }
}
