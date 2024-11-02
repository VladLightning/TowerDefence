using TMPro;
using UnityEngine;

public class AbilityDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _cooldownDisplay;

    public void UpdateCooldownDisplay(float remainingCooldown)
    {
        _cooldownDisplay.text = remainingCooldown.ToString();
    }
}
