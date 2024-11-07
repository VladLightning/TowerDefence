using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private AbilityData _abilityData;
    private AbilityDisplay _abilityDisplay;
    public AbilityDisplay AbilityDisplay { set { _abilityDisplay = value; } }

    private bool _isCooldownActive;

    private bool _isSelected;
    public bool IsSelected { get { return _isSelected; } }

    private void Start()
    {
        _abilityDisplay.SetAbilityImage(_abilityData.AbilityIcon);
    }

    public void UseAbility()
    {
        TryAbilitySelect(false);
        AbilityCast();       
    }

    public void TryAbilitySelect(bool value)
    {
        if(_isCooldownActive)
        {
            return;
        }
        _isSelected = value;
        _abilityDisplay.ActivateSelectionOutline(_isSelected);
    }

    protected virtual void AbilityCast()
    {
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
