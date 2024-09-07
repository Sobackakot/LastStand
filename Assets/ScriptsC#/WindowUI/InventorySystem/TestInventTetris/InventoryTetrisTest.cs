
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class InventoryTetrisTest : MonoBehaviour
{
    private List<Cell> cells = new List<Cell> ();
    private Cell[,] myInventory;
    private RectTransform rectTransform;
    private GridLayoutGroup myGroup;

    private void Awake()
    {
        myGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>(); 
    }

    private void Start()
    {
        Vector2 cellSize = myGroup.cellSize;
        Vector2 space = myGroup.spacing;
        float width = Mathf.CeilToInt(rectTransform.rect.x / (cellSize.x + space.x));
        float height = Mathf.CeilToInt(rectTransform.rect.y / (cellSize.y + space.y));

        byte x = (byte)Mathf.Abs(width);
        byte y = (byte)Mathf.Abs(height);

        myInventory = new Cell[y, x];

        cells.AddRange(GetComponentsInChildren<Cell>(false));
        byte indexCell = 0;

        DebugCells();
        ForCells(indexCell);
    }

    private void ForCells(byte indexCell)
    {
        for (byte Y = 0; Y < myInventory.GetLength(0); Y++)
        {
            for (byte X = 0; X < myInventory.GetLength(1); X++)
            {
                myInventory[Y, X] = cells[indexCell];
                indexCell++;
                Debug.Log("Item - " + myInventory[Y, X].gameObject.name);

            }
        } 
    }

    private void DebugCells()
    {
        Debug.Log("cells lensg - " + cells.Count);
        Debug.Log("height - " + myInventory.GetLength(0));
        Debug.Log("width - " + myInventory.GetLength(1));
    }
}
