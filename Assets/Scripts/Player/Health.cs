using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    public event Action CurrentValueChanged;

    public void ReduceCurrentValue(float damage)
    {
        if (IsAlive(_currentValue, _minValue) && isIncomingValue(damage, _minValue))
        {
            _currentValue -= damage;

            LimitCurrentValue(_currentValue, _minValue, _maxValue);

            CurrentValueChanged?.Invoke();
        }
    }

    public void IncreaseCurrentValue(float healthMedkit)
    {
        if (IsAlive(_currentValue, _minValue) && isIncomingValue(healthMedkit, _minValue))
        {
            _currentValue += healthMedkit;

            LimitCurrentValue(_currentValue, _minValue, _maxValue);

            CurrentValueChanged?.Invoke();
        }
    }

    private void LimitCurrentValue(float currentVAlue, float minValue, float maxVAlue)
    {
        _currentValue = Mathf.Clamp(currentVAlue, minValue, maxVAlue);
    }

    private bool IsAlive(float currentValue, float minValue)
    {
        return currentValue > minValue;
    }

    private bool isIncomingValue(float valueIncoming, float minValue)
    {
        return valueIncoming >= minValue;
    }
}

