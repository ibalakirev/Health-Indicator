using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    private Coroutine _coroutineSlider;

    public override void ChangeHealthBar()
    {
        if(_coroutineSlider != null)
        {
            StopCoroutine(_coroutineSlider);
        }

        _coroutineSlider = StartCoroutine(ShiftingSlowlyValueSlider());
    }

    private IEnumerator ShiftingSlowlyValueSlider()
    {
        float valueTarget = GetValueHealthForSlider();
        float speedFillHealthBar = 1f;

        while (Slider.value != valueTarget)
        {
            float currentSliderValue = Slider.value;

            Slider.value = Mathf.MoveTowards(currentSliderValue, valueTarget, speedFillHealthBar * Time.deltaTime);

            yield return null;
        }
    }
}
