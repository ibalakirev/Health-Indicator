using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 100f;

    public event Action CurrentValueChanged;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;
    public bool IsLive => _currentValue > _minValue;

    public void ReduceCurrentValue(float damage)
    {
        float multiplierDamage = -1;
        float damageValue = damage * multiplierDamage;

        if (IsLive && CheckIncomingValue(damage))
        {
            ChangeCurrentValue(damageValue);
        }
    }

    public void IncreaseCurrentValue(float healthMedkit)
    {
        if (IsLive && CheckIncomingValue(healthMedkit))
        {
            ChangeCurrentValue(healthMedkit);
        }
    }

    private void ChangeCurrentValue(float valueIncoming)
    {
        _currentValue += valueIncoming;

        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);

        CurrentValueChanged?.Invoke();
    }

    private bool CheckIncomingValue(float valueIncoming)
    {
        float minValueIncoming = 0f;

        return valueIncoming > minValueIncoming;
    }
}

