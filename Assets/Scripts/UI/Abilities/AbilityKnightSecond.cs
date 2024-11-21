using UnityEngine;

public class AbilityKnightSecond : Ability
{

    public void InitAbilityKnightSecond()
    {
        
    }
    
    protected override void AbilityCast()
    {
        base.AbilityCast();
        Debug.Log("Ability 3");
    }
}
