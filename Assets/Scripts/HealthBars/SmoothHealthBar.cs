using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SliderBar))]

public class SmoothHealthBar : HealthBar
{
    private SliderBar _slider;
    private Coroutine _coroutineSlider;

    private void Start()
    {
        _slider = GetComponent<SliderBar>();
    }

    protected override void ChangeValueIndicator()
    {
        if(_coroutineSlider != null)
        {
            StopCoroutine(_coroutineSlider);
        }

        _coroutineSlider = StartCoroutine(ShiftingSlowlyValueSlider());
    }

    private IEnumerator ShiftingSlowlyValueSlider()
    {
        float valueTarget = GetCurrentValueForSlider();
        float speedFillHealthBar = 1f;

        while (_slider.IndicatorHealthCharacter.value != valueTarget)
        {
            float currentSliderValue = _slider.IndicatorHealthCharacter.value;

            float valueSlider = Mathf.MoveTowards(currentSliderValue, valueTarget, speedFillHealthBar * Time.deltaTime);

            _slider.ChangeValueIndicator(valueSlider);

            yield return null;
        }
    }
}
