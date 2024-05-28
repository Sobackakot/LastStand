
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{ 
    private Transform transformSlot;
    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    private ItemScrObj itemScrObj;
    private ItemInSlot itemInSlot;
    private bool IsHasItem => itemInSlot != null;
     
    private void Awake()
    {
        transformSlot = GetComponent<Transform>(); 
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = transformSlot.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemAmount = transformSlot.GetChild(2).GetComponent<TextMeshProUGUI>(); 
    }
    public void AddItemToSlot(ItemScrObj newItem)
    {   
        itemScrObj = newItem; 
        itemName.text = itemScrObj.NameItem;
        itemAmount.text = itemScrObj.item.itemAmount.ToString();
        itemIcon.sprite = itemScrObj.IconItem;
        itemIcon.enabled = true;
    }
    public void CleareSlot()
    {
        itemScrObj = null; 
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " ";
    }

    public void CheckCurrentItemInSlot()
    {
        if (itemInSlot != null && itemInSlot.itemAmount < 1)
            CleareSlot();
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
        if (IsHasItem)
        {
             
        }
    }
    private void LeftButtonClickOnSlot()
    { 
        if (IsHasItem) 
        {
            
            CleareSlot();
        }   
    }
}
