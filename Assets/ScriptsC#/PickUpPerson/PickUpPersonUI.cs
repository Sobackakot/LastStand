 
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

    [HideInInspector] public string id;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleClick();
        }
    } 
    public void SetDataPersonUI(PersonDataScript data) // first set new person data in Ui slot
    {
        personDataUI = data;
        perImage.sprite = personDataUI.sprite;
        namePerson.text = personDataUI.Name;
        _hasData = true; 
    } 
    public bool HasData() // check has data in ui person slot
    {
        return _hasData;
    } 
    private void HandleClick() // check double click slot person ui
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if(timeSinceLastClick <= doubleClickThreshold)
        {
            id = personDataUI.Id;
            SystemPersonData.Instance?.SetFocusCamera(id);
        } 
        lastClickTime = Time.time;
    } 
}
