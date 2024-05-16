 
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupPerson : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    private readonly int minSlots = 1; 
    private readonly int maxSlots = 18;
    private readonly float minCellSize = 100f;
    private readonly float maxCellSize = 170f;

    [Range(1, 18)] private int currentSlotsCount = 1;
    [Range(100,170)] private float currentCellSize = 100;

    private void Start()
    {
        CharacterSwitchSystem.Instance.onUpdateCellSizeGrid += Instance_onUpdateCellSizeGrid;
        Instance_onUpdateCellSizeGrid();
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
            float cellSize = Mathf.Lerp(minCellSize, maxCellSize, (maxSlots - minSlots) / (currentSlotsCount + minSlots));
            grid.cellSize = new Vector2(cellSize, cellSize);
        }
        else  
        {
            currentCellSize = currentSlotsCount <= 7 ? 130 : 100;
            grid.cellSize = new Vector2(currentCellSize, currentCellSize);
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
