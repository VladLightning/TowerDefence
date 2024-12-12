using System;
using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public static event Func<Vector2> OnAbilityUse;
    
    [SerializeField] protected AbilityData _abilityData;
    private AbilityDisplay _abilityDisplay;
    public AbilityDisplay AbilityDisplay { set { _abilityDisplay = value; } }

    private bool _isCooldownActive;

    private bool _isSelected;
    public bool IsSelected => _isSelected;

    private void Start()
    {
        _abilityDisplay.SetAbilityImage(_abilityData.AbilityIcon);
    }

    public void UseAbility()
    {
        DeselectAbility();
        AbilityCast();       
    }

    public void TrySelectAbility()
    {
        if(_isCooldownActive)
        {
            return;
        }

        SelectAbility();
    }

    protected virtual void SelectAbility()
    {
        ActivateSelectionOutline(true);
    }

    public virtual void DeselectAbility()
    {
        ActivateSelectionOutline(false);
    }

    private void ActivateSelectionOutline(bool value)
    {
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

    protected Vector2 GetMousePosition()
    {
        return OnAbilityUse?.Invoke() ?? Vector2.zero;
    }
}
