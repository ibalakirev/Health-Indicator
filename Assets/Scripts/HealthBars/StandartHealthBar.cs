using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class StandartHealthBar : HealthBar
{
    [SerializeField] private Health _healthPlayer;

    private Slider _sliderHealthBar;

    private void Start()
    {
        _sliderHealthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _healthPlayer.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthPlayer.HealthChanged -= ChangeHealthBar;
    }

    public override void ChangeHealthBar()
    {
        _sliderHealthBar.value = GetValueHealthForSlider(_healthPlayer.CurrentHealthCharacter, _healthPlayer.MaxHealthCharacter);
    }
}
