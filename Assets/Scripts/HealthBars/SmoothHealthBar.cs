using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Health _healthPlayer;

    private Slider _sliderHealthBar;

    private float _speedFillHealthBar = 1f;

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
        _sliderHealthBar.value = Mathf.MoveTowards(GetValueHealthForSlider(_healthPlayer.CurrentHealthCharacter, _healthPlayer.MaxHealthCharacter),
            GetValueHealthForSlider(_healthPlayer.MaxHealthCharacter, _healthPlayer.MaxHealthCharacter), _speedFillHealthBar * Time.deltaTime);
    }
}
