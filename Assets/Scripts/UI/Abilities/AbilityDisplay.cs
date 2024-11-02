using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    private readonly float _inactiveImageOpacity = 0.5f;

    [SerializeField] private TMP_Text _cooldownDisplay;
    [SerializeField] private Image _abilityImage;

    public void SetAbilityImage(Sprite icon)
    {
        _abilityImage.sprite = icon;
    }

    public void UpdateCooldownDisplay(float remainingCooldown)
    {
        _cooldownDisplay.text = remainingCooldown.ToString();
    }

    public void StartCooldownVisual(float cooldown)
    {
        StartCoroutine(CooldownVisual(cooldown));
    }

    private IEnumerator CooldownVisual(float cooldown)
    {
        Color imageColor = _abilityImage.color;

        _cooldownDisplay.gameObject.SetActive(true);
        imageColor.a = _inactiveImageOpacity;
        _abilityImage.color = imageColor;

        yield return new WaitForSeconds(cooldown);
        
        _cooldownDisplay.gameObject.SetActive(false);
        imageColor.a = 1;
        _abilityImage.color = imageColor;
    }
}
