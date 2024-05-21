
using TMPro; 
using UnityEngine; 
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpPersonUI : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Additional components required!!!")]
    [Header("1). Image - avatar ")]
    [Header("2). PersonDataScript - ScriptableObject")]
    [Header("3). TextMeshProUGUI - name")]
    
    [SerializeField] private PersonDataScript personDataUI;
    [SerializeField] private TextMeshProUGUI namePerson;
    [SerializeField] private GameObject buttonDelataPerson;
    [SerializeField] private GameObject frameImage;

    private Image perImage;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;
    private bool _hasData = false;

    [HideInInspector] public string id;
    private void Awake()
    {
        perImage = GetComponent<Image>(); 
    }
    private void Start()
    {
        id = personDataUI.data.ID;
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        frameImage.SetActive(true); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        frameImage.SetActive(false); 
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
        CharacterSwitchSystem.Instance?.RemovePerson(id);
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
            CharacterSwitchSystem.Instance?.ÑharacterSwitch(in id); // camera focus on selected character from cell UI 
        }
        else
        {
            CharacterSwitchSystem.Instance?.CharacterPick(in id); //activating a character to control it
        }
        lastClickTime = Time.time;
    }  
    private void ActiveButtonRemove()
    {
        buttonDelataPerson.SetActive(true); //active button in cell
    }  
}
