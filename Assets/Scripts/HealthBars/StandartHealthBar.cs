using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class StandartHealthBar : IndicatorHealth
{
    private Slider _slider;

    public Slider Slider => _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void ChangeValueIndicator()
    {
        _slider.value = GetCurrentValueForSlider();
    }
}
