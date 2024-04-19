using UnityEngine;

[RequireComponent(typeof(SliderBar))]

public class StandartHealthBar : HealthBar
{
    private SliderBar _slider;

    private void Start()
    {
        _slider = GetComponent<SliderBar>();
    }

    protected override void ChangeValueIndicator()
    {
        float valuevalueSlider = GetCurrentValueForSlider();

        _slider.ChangeValueIndicator(valuevalueSlider);
    }
}
