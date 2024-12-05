using UnityEngine;

public class CastleCannonShotInitialize : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private TweenAnimation _animator;
    
    public void InitializeAbility(Ability ability)
    {
        var castleCannonShotAbility = ability as CastleCannonShotAbility;
        castleCannonShotAbility.InitCastleProjectileAbility(_projectileSpawnPoint,_camera, _animator);
    }
}
