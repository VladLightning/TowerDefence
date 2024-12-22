using UnityEngine;
using UnityEngine.UI;

public class HealthbarView : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        var healthBar = _healthBar.transform.parent.gameObject;

        healthBar.transform.localScale = transform.parent.localScale; //Строка для того, чтобы полоска здоровья не поворачивалась вместе с мобом
        healthBar.SetActive(currentHealth < maxHealth);

        _healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}