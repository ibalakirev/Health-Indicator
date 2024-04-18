using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.CharacterKill += SlayCharacter;
    }

    private void OnDisable()
    {
        _health.CharacterKill -= SlayCharacter;
    }

    private void SlayCharacter()
    {   
        _health.gameObject.SetActive(false);
    }
}
