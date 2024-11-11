using UnityEngine;

public class AbilityKnightFirst : Ability
{

    protected override void AbilityCast(Vector3 position)
    {
        base.AbilityCast(position);
        Debug.Log("Ability 2");
    }
}
