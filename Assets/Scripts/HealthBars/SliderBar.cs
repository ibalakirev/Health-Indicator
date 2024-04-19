using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderBar : MonoBehaviour
{
    private Slider _indicatorHealthCharacter;   
    
    public Slider IndicatorHealthCharacter => _indicatorHealthCharacter;

    private void Start()
    {
        _indicatorHealthCharacter = GetComponent<Slider>();
    }

    public void ChangeValueIndicator(float currentValueHealthBar)
    {
        _indicatorHealthCharacter.value = currentValueHealthBar;
    }
}
