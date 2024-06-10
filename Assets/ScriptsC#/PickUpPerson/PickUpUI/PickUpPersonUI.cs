
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

    [SerializeField] private PersonDataScript personDataUI;
    private TextMeshProUGUI namePerson;
    private GameObject buttonDelataPerson;
    private GameObject frameCellImage;


    private Transform transformUIPerson;
    private Image perImage;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;
    private bool _hasData = false;
     
    [HideInInspector] public string id {  get; private set; }

    private void Awake()
    {
        transformUIPerson = GetComponent<Transform>();
        perImage = GetComponent<Image>();
        namePerson = transformUIPerson.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonDelataPerson = transformUIPerson.GetChild(1).gameObject;  
        frameCellImage = transformUIPerson.GetChild(2).gameObject; 
    }
    private void Start()
    {
        characterSystem = CharacterSwitchSystem.Instance;
        id = personDataUI.data.ID;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleClick();
            frameCellImage.SetActive(true);
        }
        else
        {
            ActiveButtonRemove();
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
    public void RemoveDataPersonUI() // clear person data in Ui slot from button in cell
    {
        characterSystem?.RemovePerson(id);
        personDataUI = null;
        perImage.sprite = null;
        namePerson.text = null;
        _hasData = false;
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
        buttonDelataPerson.SetActive(true); //active button in cell
    }  
}
