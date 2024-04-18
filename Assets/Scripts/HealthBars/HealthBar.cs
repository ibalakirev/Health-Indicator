using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;

    private Slider _slider;
    public Slider Slider => _slider;
    public Health Player => _player;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        Player.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= ChangeHealthBar;
    }

    public abstract void ChangeHealthBar();

    public float GetValueHealthForSlider()
    {
        return _player.CurrentHealthCharacter / _player.MaxHealthCharacter;
    }
}
