
using System;

public abstract class AoEAbility : Ability
{
    public static event Action<float> OnAoEAbilitySelect;
    public static event Action OnAoEAbilityDeselect;
    
    protected override void SelectAbility()
    {
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
