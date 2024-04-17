using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    public abstract void ChangeHealthBar();

    public float GetValueHealthForSlider(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }
}
