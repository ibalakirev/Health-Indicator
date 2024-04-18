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

    public void ReduceHealth(float damage)
    {
        if (IsAlive())
        {
            _currentHealth -= damage;

            LimitHealth();

            HealthChanged?.Invoke();

            TryDie();
        }
    }

    public void IncreaseHealth(float healthMedkit)
    {
        if (IsAlive())
        {
            _currentHealth += healthMedkit;

            LimitHealth();

            HealthChanged?.Invoke();
        }
    }

    private void TryDie()
    {
        if (_currentHealth <= _minHealth)
        {
            gameObject.SetActive(false);
        }
    }

    private void LimitHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }

    private bool IsAlive()
    {
        return true && (_currentHealth > _minHealth);
    }
}

