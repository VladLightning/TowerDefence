using UnityEngine;
using UnityEngine.UI;

public class HealthbarView : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarImage;

    private int _maxHealth;
    
    public void UpdateHealthBar(int currentHealth)
    {
        _healthBarImage.fillAmount = (float)currentHealth / _maxHealth;
        
        _healthBar.SetActive(currentHealth < _maxHealth);
    }

    public void AlignHealthBar()
    {
        _healthBar.transform.localScale = transform.parent.localScale;
    }

    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }
}