using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextHealthBar : HealthBar
{
    [SerializeField] private Health _healthPlayer;

    private TextMeshProUGUI _textHealth;

    private void Start()
    {
        _textHealth = GetComponent<TextMeshProUGUI>();

        ChangeHealthBar();
    }

    public override void ChangeHealthBar()
    {
        _textHealth.text = $"{_healthPlayer.CurrentHealthCharacter}/{_healthPlayer.MaxHealthCharacter}";
    }
}
