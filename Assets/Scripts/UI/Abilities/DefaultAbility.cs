using System.Collections;
using TMPro;
using UnityEngine;

public class DefaultAbility : MonoBehaviour
{
    [SerializeField] private AbilityData _abilityData;
    [SerializeField] private AbilityDisplay _abilityDisplay;

    private bool _isCooldownActive;

    public void AbilityCast()
    {
        if (_isCooldownActive)
        {
            return;
        }
        StartCoroutine(AbilityCooldown());
        Debug.Log("Cast default");
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
