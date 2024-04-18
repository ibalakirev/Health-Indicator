using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;

    private Slider _slider;
    public Slider Slider => _slider;
    public Health Player => _player;
    public float CurrentHealthPlayer => _player.CurrentHealthCharacter;
    public float MaxHealthPlayer => _player.MaxHealthCharacter;

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

    public float GetValueHealthForSlider(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }
}
