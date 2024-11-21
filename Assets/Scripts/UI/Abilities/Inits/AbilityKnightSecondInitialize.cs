using UnityEngine;

public class AbilityKnightSecondInitialize : MonoBehaviour
{
    public void InitAbility(Ability ability)
    {
        var abilityKnightSecond = ability as AbilityKnightSecond;
        abilityKnightSecond.InitAbilityKnightSecond();
    }
}
