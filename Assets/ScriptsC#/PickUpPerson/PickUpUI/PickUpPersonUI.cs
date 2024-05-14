
using System.Threading.Tasks;
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
    public void Start()
    {
        id = personDataUI.data.ID;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleClick();
        }
    } 
    public void SetDataPersonUI(PersonDataScript personData) // Set first data new person in Ui slot from CharacterSwitchSystem
    {
        personDataUI = personData;  
        perImage.sprite = personDataUI.spritePerson;
        namePerson.text = personDataUI.namePerson;
        _hasData = true; 
    }
    public void �learDataPersonUI() // clear person data in Ui slot ...
    {
        personDataUI = null;
        perImage.sprite = null;
        namePerson.text = null; 
    }
    public bool HasData() // check has data in ui person slot from CharacterSwitchSystem
    {
        return _hasData;
    } 
  
    private void HandleClick() // check double click slot person ui
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if(timeSinceLastClick <= doubleClickThreshold)
        { 
            CharacterSwitchingSystem.Instance?.SetFocusCamera(in id);
        } 
        lastClickTime = Time.time;
    } 
}
