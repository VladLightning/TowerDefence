
using System;

public abstract class AoEAbility : Ability
{
    public static event Action<float> OnAoEAbilitySelect;
    public static event Action OnAoEAbilityDeselect;
    
    public override void SelectAbility()
    {
        if (_isCooldownActive)
        {
            return;
        }
        base.SelectAbility();
        var aoeAbilityData = _abilityData as AoEAbilityData;
        OnAoEAbilitySelect?.Invoke(aoeAbilityData.Radius);
    }

    public override void DeselectAbility()
    {
        base.DeselectAbility();
        OnAoEAbilityDeselect?.Invoke();
    }
}
