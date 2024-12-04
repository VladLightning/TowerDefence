using UnityEngine;

public class AbilityFreezeInitialize : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private TweenAnimation _animator;
    
    public void InitAbility(Ability ability)
    {
        var abilityFreeze = ability as FreezeAbility;
        abilityFreeze.InitCastleProjectileAbility(_projectileSpawnPoint, _camera, _animator);
    }
}
