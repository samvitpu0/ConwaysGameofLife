using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSimulator : MonoBehaviour
{
    [Header("Reference of the Grid Generator")]
    public GridGenerator gridHolder;

    public float simulationSpeed = 1f;

    private int neighbourCount = 0;

    /// <summary>
    /// The List which holds the cells which are to be given life
    /// </summary>
    private List<GameObject> livingCells;

    /// <summary>
    /// The List holds the cells which are to be killed
    /// </summary>
    private List<GameObject> deadCells;
    
    /// <summary>
    /// This function applies rules of life and simulate one generation
    /// </summary>
    public void NextGeneration()
    {
        livingCells = new List<GameObject>();
        deadCells = new List<GameObject>();

        //Clearing list for next generation
        livingCells.Clear();
        deadCells.Clear();

        //counting neighbours
        for(int i = 0; i<gridHolder.orderOfGrid; i++)
        {
            for (int j = 0; j < gridHolder.orderOfGrid; j++)
            {
                if (i < gridHolder.orderOfGrid - 1)
                    if (gridHolder.Grid[i + 1][j] != null)
                        if (gridHolder.Grid[i + 1][j].GetComponent<CellInfo>().alive)
                            neighbourCount++;
                if (i > 0)
                    if (gridHolder.Grid[i - 1][j] != null)
                        if (gridHolder.Grid[i - 1][j].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j < gridHolder.orderOfGrid - 1)
                    if (gridHolder.Grid[i][j + 1] != null)
                        if (gridHolder.Grid[i][j + 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j > 0)
                    if (gridHolder.Grid[i][j - 1] != null)
                        if (gridHolder.Grid[i][j - 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j < gridHolder.orderOfGrid - 1 && i < gridHolder.orderOfGrid - 1)
                    if (gridHolder.Grid[i + 1][j + 1] != null)
                        if (gridHolder.Grid[i + 1][j + 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j < gridHolder.orderOfGrid - 1 && i > 0)
                    if (gridHolder.Grid[i - 1][j + 1] != null)
                        if (gridHolder.Grid[i - 1][j + 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j > 0 && i > 0)
                    if (gridHolder.Grid[i - 1][j - 1] != null)
                        if (gridHolder.Grid[i - 1][j - 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;

                if (j > 0 && i < gridHolder.orderOfGrid - 1)
                    if (gridHolder.Grid[i + 1][j - 1] != null)
                        if (gridHolder.Grid[i + 1][j - 1].GetComponent<CellInfo>().alive)
                            neighbourCount++;


                //applying life rules to determine which cell to kill and which to make alive and adding them to Lists
                if (gridHolder.Grid[i][j].GetComponent<CellInfo>().alive)
                {
                    if (neighbourCount < 2)
                        deadCells.Add(gridHolder.Grid[i][j]);

                    if (neighbourCount > 3)
                        deadCells.Add(gridHolder.Grid[i][j]);
                }
                else
                {
                    if (neighbourCount == 3)
                        livingCells.Add(gridHolder.Grid[i][j]);
                }
                neighbourCount = 0;


            }
        }

        foreach (GameObject cell in livingCells)
            cell.GetComponent<CellInfo>().Live();

        foreach (GameObject cell in deadCells)
            cell.GetComponent<CellInfo>().Die();
    }

    /// <summary>
    /// This function will be called on Start Click
    /// </summary>
    public void StartSimulation()
    {
        StartCoroutine("DoStartSimulation");
    }

    /// <summary>
    /// This funcion will execute for indefinite time till the user click Stop button
    /// </summary>
    /// <returns></returns>
    IEnumerator DoStartSimulation()
    {
        while (true)
        {
            NextGeneration();
            yield return new WaitForSeconds(simulationSpeed);
        }
    }

    /// <summary>
    /// This function will be called on Stop Click
    /// </summary>
    public void StopSimulation()
    {
        StopCoroutine("DoStartSimulation");
    }
}
