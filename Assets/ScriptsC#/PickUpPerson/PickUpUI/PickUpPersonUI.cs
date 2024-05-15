
using TMPro; 
using UnityEngine; 
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpPersonUI : MonoBehaviour , IPointerClickHandler
{
    [Header("Additional components required!!!")]
    [Header("1). Image - avatar ")]
    [Header("2). PersonDataScript - ScriptableObject")]
    [Header("3). TextMeshProUGUI - name")]
    
    [SerializeField] private PersonDataScript personDataUI;
    [SerializeField] private TextMeshProUGUI namePerson;

    private Image perImage;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;
    private bool _hasData = false;

    [HideInInspector] public string id;
    private void Awake()
    {
        perImage = GetComponent<Image>();
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
        id = personDataUI.data.ID;
        perImage.sprite = personDataUI.spritePerson;
        namePerson.text = personDataUI.namePerson;
        _hasData = true; 
    }
    public void ÑlearDataPersonUI() // clear person data in Ui slot ...
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
            CharacterSwitchingSystem.Instance?.ÑharacterSwitch(in id);
        }
        else
        {
            CharacterSwitchingSystem.Instance?.CharacterPick(in id);
        }
        lastClickTime = Time.time;
    }  
}
