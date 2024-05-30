
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryContoller inventorySystem;
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
    private void Start()
    {
        inventorySystem = InventoryContoller.Instance;
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
        
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DownSlot");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
       
    }

    
     
    public void OnPointerEnter(PointerEventData eventData)
    {
        bool isDragg = inventorySystem.currentItem.IsDragging();
        inventorySystem.currentItem.UpdatePointEnter(transformSlot);
        Debug.Log("isDragg = " + isDragg);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         
    }
}
