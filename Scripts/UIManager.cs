using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("SLiders used to modify Grid Size and Simulation Speed")]
    public Slider gridSlider;
    public Slider speedSlider;

    [Header("Text to show current Grid Size and Simulation Speed")]
    public Text gridSizeText;
    public Text speedText;

    /// <summary>
    /// References to Grid Generator and Generation Simulator
    /// </summary>
    public GridGenerator gridGenerator;
    public GenerationSimulator simulator;

    /// <summary>
    /// This will be called when Grid Size slider value is changed
    /// </summary>
    public void GridSliderValueChanged()
    {
        simulator.StopSimulation();
        gridGenerator.ClearGrid();
        gridGenerator.orderOfGrid = (int)gridSlider.value;
        gridSizeText.text = gridSlider.value.ToString();
        gridGenerator.CreateGrid();
        
    }

    /// <summary>
    /// This will be called when Simulation Speed slider value is changed
    /// </summary>
    public void SpeedSliderValueChanged()
    {
        simulator.simulationSpeed = 1 - speedSlider.value;
        speedText.text = (1f - speedSlider.value).ToString("f2") + "Sec";
    }

    /// <summary>
    /// This will be called on Reset button click
    /// </summary>
    public void ResetGrid()
    {
        simulator.StopSimulation();
        gridGenerator.ClearGrid();
        gridGenerator.CreateGrid();
    }
}
