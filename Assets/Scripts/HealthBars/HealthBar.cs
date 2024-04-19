using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;
    public Health Player => _player;

    private void OnEnable()
    {
        Player.CurrentValueChanged += ChangeValueIndicator;
    }

    private void OnDisable()
    {
        Player.CurrentValueChanged -= ChangeValueIndicator;
    }

    protected abstract void ChangeValueIndicator();

    protected float GetCurrentValueForSlider()
    {
        return _player.CurrentValue / _player.MaxValue;
    }
}
