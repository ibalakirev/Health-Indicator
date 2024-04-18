using UnityEngine.UI;

public class StandartHealthBar : HealthBar
{
    public override void ChangeHealthBar()
    {
        Slider.value = GetValueHealthForSlider();
    }
}
