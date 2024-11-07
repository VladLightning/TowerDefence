using UnityEngine;

public class AbilityKnightFirst : Ability
{

    protected override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 2");
    }
}
