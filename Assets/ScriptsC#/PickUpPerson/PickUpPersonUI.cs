 
using TMPro; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpPersonUI : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private Image perImage;
    [SerializeField] private TextMeshProUGUI namePerson;
    [SerializeField] private PersonDataScript personDataUI;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.5f;
    private bool _hasData = false; 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleClick();
        }
    } 
    public void SetDataPersonUI(PersonDataScript data)
    {
        personDataUI = data;
        perImage.sprite = personDataUI.sprite;
        namePerson.text = personDataUI.Name;
        _hasData = true; 
    } 
    public bool HasData()
    {
        return _hasData;
    } 
    private void HandleClick()
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if(timeSinceLastClick <= doubleClickThreshold)
        {
            Debug.Log("DoubleClick");
        } 
        lastClickTime = Time.time;
        Debug.Log("Click");
    } 
}
