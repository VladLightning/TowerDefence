using UnityEngine;

public class CastleCannonShotInitialize : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private TweenAnimation _animator;
    
    public void InitAbility(Ability ability)
    {
        var castleCannonShotAbility = ability as CastleCannonShotAbility;
        castleCannonShotAbility.InitCastleCannonShotAbility(_projectileSpawnPoint,_camera, _animator);
    }
}
