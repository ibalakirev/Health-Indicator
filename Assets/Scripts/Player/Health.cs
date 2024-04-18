using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _minHealth = 0f;
    [SerializeField] private float _maxHealth = 100f;

    public float CurrentHealthCharacter => _currentHealth;
    public float MaxHealthCharacter => _maxHealth;

    public event Action HealthChanged;
    public event Action CharacterKill;

    public void ReduceHealth(float damage)
    {
        if (IsAlive(damage))
        {
            float multiplierÌalueDamage = -1;
            float valueDamage = damage * multiplierÌalueDamage;

            ChangeHealthCharacter(valueDamage);

            TryDie();
        }
    }

    public void IncreaseHealth(float healthMedkit)
    {
        if (IsAlive(healthMedkit))
        {
            ChangeHealthCharacter(healthMedkit);

            HealthChanged?.Invoke();
        }
    }

    private void ChangeHealthCharacter(float health)
    {
        _currentHealth += health;

        LimitHealth();

        HealthChanged?.Invoke();
    }

    private void TryDie()
    {
        if (_currentHealth <= _minHealth)
        {
            CharacterKill?.Invoke();
        }
    }

    private void LimitHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }

    private bool IsAlive(float valueIncoming)
    {
        float minValueIncoming = 0;

        return _currentHealth > _minHealth && valueIncoming >= minValueIncoming;
    }
}

