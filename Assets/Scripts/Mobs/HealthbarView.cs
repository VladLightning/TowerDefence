using UnityEngine;
using UnityEngine.UI;

public class HealthbarView : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarImage;
    
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        _healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        
        _healthBar.SetActive(currentHealth < maxHealth);
    }

    public void AlignHealthBar()
    {
        _healthBar.transform.localScale = transform.parent.localScale;
    }
}