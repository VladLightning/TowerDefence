using UnityEngine;

public class FreezeAbilityInitialize : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private TweenAnimation _animator;
    
    public void InitializeAbility(Ability ability)
    {
        var abilityFreeze = ability as FreezeAbility;
        abilityFreeze.InitCastleProjectileAbility(_projectileSpawnPoint, _animator);
    }
}
