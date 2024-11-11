using UnityEngine;

public class AbilityKnightSecond : Ability
{

    protected override void AbilityCast(Vector3 position)
    {
        base.AbilityCast(position);
        Debug.Log("Ability 3");
    }
}
