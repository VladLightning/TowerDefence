using UnityEngine;

public class AbilityKnightSecond : Ability
{

    public override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 3");
    }
}
