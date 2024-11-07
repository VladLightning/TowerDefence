using UnityEngine;

public class DefaultAbility : Ability
{

    protected override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability default");
    }
}
