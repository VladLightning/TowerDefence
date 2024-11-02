using System.Collections;
using TMPro;
using UnityEngine;

public class DefaultAbility : MonoBehaviour
{
    [SerializeField] private AbilityData _abilityData;
    [SerializeField] private AbilityDisplay _abilityDisplay;

    private bool _isCooldownActive;

    private void Start()
    {
        _abilityDisplay.SetAbilityImage(_abilityData.AbilityIcon);
    }

    public void AbilityCast()
    {
        if (_isCooldownActive)
        {
            return;
        }
        _abilityDisplay.StartCooldownVisual(_abilityData.AbilityCooldown);
        StartCoroutine(AbilityCooldown());
    }

    private IEnumerator AbilityCooldown()
    {
        _isCooldownActive = true;
        float cooldown = _abilityData.AbilityCooldown;

        while (cooldown > 0)
        {          
            _abilityDisplay.UpdateCooldownDisplay(cooldown);
            yield return new WaitForSeconds(1);
            cooldown--;
        }

        _isCooldownActive = false;
    }
}
