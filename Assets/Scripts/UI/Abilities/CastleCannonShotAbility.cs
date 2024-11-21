using DG.Tweening;
using UnityEngine;

public class CastleCannonShotAbility : Ability
{
    [SerializeField] private GameObject _projectile;
    
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _animationDuration;
    
    private Transform _projectileSpawnPoint;
    private Camera _camera;
    private TweenAnimation _animator;

    public void InitCastleCannonShotAbility(Transform projectileSpawnPoint, Camera camera, TweenAnimation animator)
    {
        _projectileSpawnPoint = projectileSpawnPoint;
        _camera = camera;
        _animator = animator;
    }
    
    protected override void AbilityCast()
    {
        Debug.Log("Cast CastleCannonShotAbility");
        base.AbilityCast();
        var projectile = Instantiate(_projectile, _projectileSpawnPoint.position, _projectile.transform.rotation);

        //var position = _camera.ScreenToWorldPoint(Mouse.current.position.value);
        
        //_animator.StartCoroutine(_animator.PointAtoB(projectile.transform, position, _easeType, _animationDuration));
    }
}
