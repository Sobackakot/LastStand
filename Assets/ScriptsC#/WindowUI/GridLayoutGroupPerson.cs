 
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupPerson : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    [Range(1, 9)] private int minSlots = 1; 
    [Range(1,9)]  private int maxSlots = 18;
    private int middleSlots =4;
    private readonly float minCellSize = 100f;
    private readonly float maxCellSize = 170f;


    private int currentSlotsCount = 0;
    private float currentCellSize = 1;
    private void Start()
    {
        CharacterSwitchSystem.Instance.onUpdateCellSizeGrid += Instance_onUpdateCellSizeGrid;
    }
    private void OnDisable()
    {
        CharacterSwitchSystem.Instance.onUpdateCellSizeGrid -= Instance_onUpdateCellSizeGrid;
    }

    private void Instance_onUpdateCellSizeGrid()
    {
        currentSlotsCount = GetCurrentActiveSlot();
        if (currentSlotsCount <6)
        {
            float cellSize = Mathf.Lerp(minCellSize, maxCellSize, (maxSlots - minSlots) / (currentCellSize = currentSlotsCount <= middleSlots ? middleSlots : (currentSlotsCount - minSlots)));
            grid.cellSize = new Vector2(cellSize, cellSize);
        }
        else
        {
            float cellSize = Mathf.Lerp(maxCellSize, minCellSize, (currentCellSize = currentSlotsCount <= middleSlots ? middleSlots : (currentSlotsCount - minSlots)) / (maxSlots - minSlots));
            grid.cellSize = new Vector2(cellSize, cellSize);
        }
    }
    private int GetCurrentActiveSlot()
    {
        currentSlotsCount = 0;
        foreach (Transform child in grid.transform)
        {
            if (child.gameObject.activeSelf)
            { 
                currentSlotsCount++;
                Debug.Log(currentSlotsCount);
            }
        }
        return currentSlotsCount;
    }
}
