using UnityEngine;

public class CastleCannonShotAbilityInitialize : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private TweenAnimation _animator;
    
    public void InitializeAbility(Ability ability)
    {
        var castleCannonShotAbility = ability as CastleCannonShotAbility;
        castleCannonShotAbility.InitCastleProjectileAbility(_projectileSpawnPoint, _animator);
    }
}
