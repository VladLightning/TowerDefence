using UnityEngine;

public class AbilityKnightFirst : Ability
{

    public void InitAbilityKnightFirst()
    {
        
    }

    protected override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 2");
    }
}
