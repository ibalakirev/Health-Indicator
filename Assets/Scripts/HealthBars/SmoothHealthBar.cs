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
        float valueTarget = GetValueHealthForSlider(CurrentHealthPlayer, MaxHealthPlayer);
        float waitTime = 0.05f;
        float speedFillHealthBar = 2f;

        WaitForSeconds wait = new WaitForSeconds(waitTime);

        while (Slider.value != valueTarget)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, GetValueHealthForSlider(CurrentHealthPlayer, MaxHealthPlayer), speedFillHealthBar * Time.deltaTime);

            yield return wait;
        }
    }
}
