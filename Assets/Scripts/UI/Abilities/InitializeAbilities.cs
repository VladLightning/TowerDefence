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
                    GetComponentInChildren<CastleCannonShotAbilityInitialize>().InitializeAbility(ability);
                    break;
                case FreezeAbility:
                    GetComponentInChildren<FreezeAbilityInitialize>().InitializeAbility(ability);
                    break;
                case TornadoAbility:
                    //Nothing to initialize
                    break;
            }
        }
    }
}
