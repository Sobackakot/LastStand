
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public int slotIndex {  get; private set; }
    public ItemScrObj dataItem { get; private set;}

    private RectTransform pickItemTransform;
    [HideInInspector] public Transform originalParent;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;

    private void Awake()
    {   
        originalParent = GetComponent<Transform>();
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>();

        itemIcon = GetComponent<Image>();
        itemName = pickItemTransform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemAmount = pickItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    public virtual void SetItem(ItemScrObj newItem) // coll from InventoryUI
    {
        if (newItem == null) return;
        dataItem = newItem;
        itemName.text = dataItem.NameItem;
        itemAmount.text = dataItem.item.itemAmount.ToString();
        itemIcon.sprite = dataItem.IconItem;
        itemIcon.enabled = true;
    }
    public virtual void CleareItem() // coll from InventoryUI
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
        originalParent = transform.parent;
        pickItemTransform.SetParent(canvas.transform);
        pickItemTransform.SetAsLastSibling(); 
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        pickItemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        pickItemTransform.SetParent(originalParent);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dataItem?.UseItem();
        }
    } 
}
