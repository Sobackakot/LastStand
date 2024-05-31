 
using UnityEngine;
using UnityEngine.EventSystems;

//Script from new Scena !!!!!
public class ItemDrugByGridTest : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _transform;
    [HideInInspector] public  Transform currentTransform;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;
    private void Awake()    
    {
        _transform = GetComponent<RectTransform>(); 
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = _transform.GetComponentInParent<Canvas>();    
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.5f;
        currentTransform = transform.parent; //get starting position
        _transform.SetParent(_canvas.transform); //set parent canvas object
        _transform.SetAsLastSibling(); //set the layer priority
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor; //move the object behind the mouse cursor relative to the size of the canvas
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
        _transform.SetParent(currentTransform);//set the parent object's starting position
    }
}
