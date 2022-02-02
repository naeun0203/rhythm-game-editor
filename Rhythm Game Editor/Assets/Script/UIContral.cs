using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContral : MonoBehaviour
{
    public Slider slider;
    public Grid grid;
    public EditorManager manager;
    public void HandleChange(float value)
    {
        SliderValue(value, 0.5f);

        switch (slider.value)
        {
            case 0:
                grid.BeatSetActive(true, true);
                break;
            case 0.5f:
                grid.BeatSetActive(false, true);
                break;
            case 1:
                grid.BeatSetActive(false, false);
                break;
        }
    }

    public void ColorSelect(float value)
    {
        SliderValue(value, 1);
        switch (slider.value)
        {
            case 0:
                manager.noteContral.ChangeColor(0);
                break;
            case 1:
                manager.noteContral.ChangeColor(1);
                break;
        }
    }

    private void SliderValue(float value, float roundToMultipleOf)
    {
        slider.value = Mathf.Round(value / roundToMultipleOf) * roundToMultipleOf;
                
    }
}
