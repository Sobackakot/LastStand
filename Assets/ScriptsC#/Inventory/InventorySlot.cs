
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private InventoryContoller inventory;

    private RectTransform transformSlot;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    private ItemScrObj itemScrObj; 
     
    private void Awake()
    {
        transformSlot = GetComponent<RectTransform>(); 
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = transformSlot.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemAmount = transformSlot.GetChild(2).GetComponent<TextMeshProUGUI>();
        inventory = InventoryContoller.Instance;
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
    public void OnPointerClick(PointerEventData eventData)
    { 
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            LeftButtonClickOnSlot();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
    }

    public void OnDrop(PointerEventData eventData)
    {
         
    }
    private void LeftButtonClickOnSlot()
    { 
        inventory.currentItem.PickUpItem(itemScrObj, transformSlot); 
    }
}
