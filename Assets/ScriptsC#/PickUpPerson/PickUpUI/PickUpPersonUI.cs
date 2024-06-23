
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

    private CharacterSwitchSystem characterSystem;

    [SerializeField] private PersonDataScript personDataUI; // ScriptableObject data of Person
    private TextMeshProUGUI namePerson; 
    private GameObject buttonDelataPerson; //  UI Button for Disable person cell 
    private GameObject frameCellImage; // Frame UI Image for show current pick person 


    private Transform transformUIPerson; // current position UI cell from grid
    private Image personAvatar; // current Ui Image for person from cell

    private float lastClickTime = 0f; //seconds to check the elapsed time between clicks
    private float doubleClickThreshold = 0.3f; //time between double clicks
    private bool _hasData = false; //checkbox to check initialization of character data

    public string id {  get; private set; } // get a unique character ID

    private void Awake()
    {
        transformUIPerson = GetComponent<Transform>();
        personAvatar = GetComponent<Image>();
        namePerson = transformUIPerson.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonDelataPerson = transformUIPerson.GetChild(1).gameObject;  
        frameCellImage = transformUIPerson.GetChild(2).gameObject; 
    }
    private void Start()
    {
        characterSystem = CharacterSwitchSystem.Instance;
        id = personDataUI.data.ID;
    }

    public void EnableFrameByCell() //coll from class CharacterSwitchSystem 
    {
        frameCellImage?.SetActive(true);
    }
    public void DisableFrameByCell() //coll from class CharacterSwitchSystem 
    {
        frameCellImage?.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleClick(); 
        }
        else
        {
            ActiveButtonRemove();
        }
    }
    // Set first data new person in Ui slot  
    public void SetDataPersonUI(PersonDataScript personData) //coll from class CharacterSwitchSystem
    {
        personDataUI = personData;
        id = personDataUI.data.ID;
        personAvatar.sprite = personDataUI.spritePerson;
        namePerson.text = personDataUI.namePerson;
        _hasData = true; 
    }
    public void RemoveDataPersonUI() //Button clear person data in Ui slot from button in cell
    {
        characterSystem?.RemovePerson(id);
        personDataUI = null;
        personAvatar.sprite = null;
        namePerson.text = null;
        _hasData = false;
    }
    // check has data in ui person slot
    public bool HasData() //coll from class CharacterSwitchSystem 
    {
        return _hasData;
    } 
  
    private void HandleClick() // check double click slot person ui
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if(timeSinceLastClick <= doubleClickThreshold)
        {
            characterSystem?.ÑharacterSwitch(id); // camera focus on selected character from cell UI 
        }
        else
        {
            characterSystem?.CharacterPick(id); //activating a character to control it 
        }
        lastClickTime = Time.time;
    }  
    private void ActiveButtonRemove()
    {
        buttonDelataPerson.SetActive(true); //active button from cell
    }  
}
