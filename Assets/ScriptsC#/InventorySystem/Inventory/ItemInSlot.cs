
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class ItemInSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public int slotIndex {  get; set; }
    public ItemScrObj dataItem { get; private set;}
    private InventoryController inventory;
    private EquipmentController equipment;

    private RectTransform pickItemTransform;
    private Transform originalParent;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;

    [Inject]
    private void Container(InventoryController inventory, EquipmentController equipment)
    {
        this.inventory = inventory;
        this.equipment = equipment;
    }

    private void Awake()
    {   
        originalParent = GetComponent<Transform>();  //transform parent object
        pickItemTransform = GetComponent<RectTransform>();//current position of the item
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>(); //UI canvas with inventory

        itemIcon = GetComponent<Image>(); //image of the current item
        itemName = pickItemTransform.GetChild(0).GetComponent<TextMeshProUGUI>(); //name of the current item
        itemAmount = pickItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>(); //amount of current item
    }
    public virtual void SetItem(ItemScrObj newItem) // coll from InventorySlot
    {
        if (newItem == null) return;
        dataItem = newItem;
        itemName.text = dataItem.NameItem;
        itemAmount.text = dataItem.item.itemAmount.ToString();
        itemIcon.sprite = dataItem.IconItem;
        itemIcon.enabled = true;
    }
    public virtual void CleareItem() // coll from InventorySlot
    {
        dataItem = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " "; 
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        originalParent = transform.parent; //save the parent object of the item
        pickItemTransform.SetParent(canvas.transform); //changing the parent object of an item
        pickItemTransform.SetAsLastSibling(); //sets item display priority
    }
    public virtual void OnDrag(PointerEventData eventData) //moves an item to the mouse cursor position
    {
        pickItemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        pickItemTransform.SetParent(originalParent); //returns the item to the original position of the parent object
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && dataItem != null)
        {   
            if(dataItem.IndexOfSlot != EquipItem.None) 
            {
                equipment.EquipItem(dataItem);
                inventory.RemoveItemFromInventory(dataItem);
            }  
        }
    } 
}
