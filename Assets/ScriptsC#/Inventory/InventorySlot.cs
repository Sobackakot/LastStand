
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private ItemScrObj itemScrObj; 

    private RectTransform transformSlot;
    private RectTransform transformItem;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    
     
    private void Awake()
    {
        transformSlot = GetComponent<RectTransform>();
        transformItem = transformSlot.GetChild(0).GetComponent<RectTransform>();
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
    public void OnPointerEnter(PointerEventData eventData)
    {
         
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
         
    }
  

    public void OnDrop(PointerEventData eventData)
    {
       transformItem.position = transformSlot.position;
    }   
}
