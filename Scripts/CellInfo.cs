using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellInfo : MonoBehaviour
{
    /// <summary>
    /// This will tell the status of the cell
    /// </summary>
    [HideInInspector]
    public bool alive = false;

    /// <summary>
    /// This will make cell color Black which denotes Living Cell
    /// </summary>
    public void Live()
    {
        alive = true;
        GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }

    /// <summary>
    /// This will make cell color White which denotes Dead Cell
    /// </summary>
    public void Die()
    {
        alive = false;
        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
