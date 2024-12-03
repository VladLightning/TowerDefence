using TMPro;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthDisplay;

    [SerializeField] private int _maxHealth;
    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        UpdateHealthDisplay();
    }

    private void OnEnable()
    {
        Enemy.OnDealDamageToPlayer += TakeDamage;
    }

    private void OnDisable()
    {
        Enemy.OnDealDamageToPlayer -= TakeDamage;
    }

    private void UpdateHealthDisplay()
    {
        _healthDisplay.text = _health.ToString();
    }

    private void Defeat()
    {
        Debug.Log("Defeat");
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }

        UpdateHealthDisplay();

        if (_health == 0 )
        {
            Defeat();
        }
    }   
}
