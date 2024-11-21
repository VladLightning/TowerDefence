using UnityEngine;

public class AbilityKnightFirstInitialize : MonoBehaviour
{
    public void InitAbility(Ability ability)
    {
        var abilityKnightFirst = ability as AbilityKnightFirst;
        abilityKnightFirst.InitAbilityKnightFirst();
    }
}
