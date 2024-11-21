using UnityEngine;

public class InitializeAbilities : MonoBehaviour
{
    private void OnEnable()
    {
        HeroSpawner.OnAbilitiesSpawned += InitAbilities;
    }

    private void OnDisable()
    {
        HeroSpawner.OnAbilitiesSpawned -= InitAbilities;
    }

    private void InitAbilities(Ability[] abilities)
    {
        foreach (var ability in abilities)
        {
            switch (ability)
            {
                case CastleCannonShotAbility:
                    GetComponentInChildren<CastleCannonShotInitialize>().InitAbility(ability);
                    break;
                case AbilityKnightFirst:
                    GetComponentInChildren<AbilityKnightFirstInitialize>().InitAbility(ability);
                    break;
                case AbilityKnightSecond:
                    GetComponentInChildren<AbilityKnightSecondInitialize>().InitAbility(ability);
                    break;
            }
        }

    }
}
