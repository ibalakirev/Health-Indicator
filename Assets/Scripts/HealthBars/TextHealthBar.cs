using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;

    private TextMeshProUGUI _textHealth;

    private void Start()
    {
        _textHealth = GetComponent<TextMeshProUGUI>();

        ChangeHealthBar();
    }

    private void OnEnable()
    {
        _healthPlayer.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthPlayer.HealthChanged -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        _textHealth.text = $"{_healthPlayer.CurrentHealthCharacter}/{_healthPlayer.MaxHealthCharacter}"; 
    }
}
