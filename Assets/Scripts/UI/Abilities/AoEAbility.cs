
using System;
using UnityEngine;

public abstract class AoEAbility : Ability
{
    public static event Action<float, Transform> OnAoEAbilitySelect;
    public static event Action OnAoEAbilityDeselect;

    public static event Action OnDisableRangedRadius;
    
    protected override void SelectAbility()
    {
        base.SelectAbility();
        var aoeAbilityData = _abilityData as AoEAbilityData;
        OnDisableRangedRadius?.Invoke();
        OnAoEAbilitySelect?.Invoke(aoeAbilityData.Radius, null);
    }

    public override void DeselectAbility()
    {
        base.DeselectAbility();
        OnAoEAbilityDeselect?.Invoke();
    }
}
