using UnityEngine;

public class AbilityKnightFirst : Ability
{

    public override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 2");
    }
}
