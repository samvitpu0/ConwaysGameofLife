using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    /// <summary>
    /// The GameObject which will be replicated to create the grid of cells
    /// </summary>
    [Header("Prefab of the cell GameObject")]
    public GameObject gridTile;

    [Header("Parent Under which prefabs will be instantiated")]
    public Transform parent;

    [Header("Order of the square grid")]
    public int orderOfGrid = 30;

    /// <summary>
    /// The Grid arrray this is used to access all the cells
    /// </summary>
    public GameObject[][] Grid;

    private List<GameObject> cells;

    void Start()
    {
        Grid = new GameObject[orderOfGrid][];
        for (int i = 0; i < orderOfGrid; i++)
            Grid[i] = new GameObject[orderOfGrid];

        cells = new List<GameObject>();

        CreateGrid();
    }

    /// <summary>
    /// Creates the grid of tiles and place the tiles on grid
    /// </summary>
    public void CreateGrid()
    {
        int _width = (int)gridTile.GetComponent<RectTransform>().rect.width;
        int _xPos = _width;
        int _yPos = -1 * _width;
        int _padding = 5;

        for(int i=0; i<orderOfGrid; i++)
        {
            for(int j=0; j<orderOfGrid; j++)
            {
                Grid[i][j] = Instantiate(gridTile,parent);
                Grid[i][j].GetComponent<RectTransform>().anchoredPosition = new Vector2(_xPos, _yPos);

                _xPos = _xPos + _width + _padding;

                cells.Add(Grid[i][j]);
            }
            _xPos = _width;
            _yPos = _yPos - _width - _padding;
        }
    }

    public void ClearGrid()
    {
        foreach (GameObject cell in cells)
            Destroy(cell);
    }
}
