using UnityEngine;

public class AbilityKnightSecond : Ability
{

    protected override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 3");
    }
}
