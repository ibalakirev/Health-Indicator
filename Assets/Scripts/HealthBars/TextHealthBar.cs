using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextHealthBar : IndicatorHealth
{
    private TextMeshProUGUI _indicator;

    private void Start()
    {
        _indicator = GetComponent<TextMeshProUGUI>();

        ChangeValueIndicator();
    }

    protected override void ChangeValueIndicator()
    {
        _indicator.text = $"{Player.CurrentValue}/{Player.MaxValue}";
    }
}
