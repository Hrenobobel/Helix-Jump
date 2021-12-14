using UnityEngine.UI;
using UnityEngine;

public class SliderValueText : MonoBehaviour
{
    public Slider Slider;
    public Text Text;

    void Update()
    {
        float CurrentSlider = Slider.value *= 100;
        string SliderString = CurrentSlider.ToString("F0");
        Text.text = SliderString + "% COMPLETED";

    }
}
