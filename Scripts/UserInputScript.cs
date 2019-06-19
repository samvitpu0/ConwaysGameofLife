using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputScript : MonoBehaviour
{
    /// <summary>
    /// This will toggle if the cell is living or dead on Click
    /// </summary>
    public void ToggleLife()
    {
        if(!GetComponent<CellInfo>().alive)
        {
            GetComponent<CellInfo>().Live();
        }
        else
        {
            GetComponent<CellInfo>().Die();
        }
    }
}
