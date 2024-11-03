using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    private readonly float _inactiveImageOpacity = 0.5f;

    [SerializeField] private TMP_Text _cooldownDisplay;
    [SerializeField] private Image _abilityImage;

    private Color _imageColor;

    public void SetAbilityImage(Sprite icon)
    {
        _abilityImage.sprite = icon;
        _imageColor = _abilityImage.color;
    }

    public void UpdateCooldownDisplay(float remainingCooldown)
    {
        _cooldownDisplay.text = remainingCooldown.ToString();
    }

    public void UpdateAbilityImage(bool isDisabled)
    {
        _cooldownDisplay.gameObject.SetActive(isDisabled);
        _imageColor.a = isDisabled ? _inactiveImageOpacity : 1;
        _abilityImage.color = _imageColor;
    }
}
