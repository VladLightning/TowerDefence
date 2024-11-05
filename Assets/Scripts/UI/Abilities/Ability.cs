using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
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
        StartCoroutine(AbilityCooldown());
    }

    private IEnumerator AbilityCooldown()
    {
        _isCooldownActive = true;
        float cooldown = _abilityData.AbilityCooldown;

        _abilityDisplay.UpdateAbilityImage(true);

        while (cooldown > 0)
        {          
            _abilityDisplay.UpdateCooldownDisplay(cooldown);
            yield return new WaitForSeconds(1);
            cooldown--;
        }

        _abilityDisplay.UpdateAbilityImage(false);

        _isCooldownActive = false;
    }
}
