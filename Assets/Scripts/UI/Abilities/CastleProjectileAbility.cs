using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class CastleProjectileAbility : Ability
{
    [SerializeField] private GameObject _projectile;
    
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _animationDuration;
    
    private Transform _projectileSpawnPoint;
    private Camera _camera;
    private TweenAnimation _animator;
    
    protected abstract void InitProjectile(GameObject projectile);
    
    public void InitCastleProjectileAbility(Transform projectileSpawnPoint, Camera camera, TweenAnimation animator)
    {
        _projectileSpawnPoint = projectileSpawnPoint;
        _camera = camera;
        _animator = animator;
    }
        
    protected override void AbilityCast()
    {
        base.AbilityCast();
        var projectile = Instantiate(_projectile, _projectileSpawnPoint.position, _projectile.transform.rotation);
        
        InitProjectile(projectile);
        StartCoroutine(ProjectileShoot(projectile));
    }

    private IEnumerator ProjectileShoot(GameObject projectile)
    {
        var position = _camera.ScreenToWorldPoint(Mouse.current.position.value);
        yield return _animator.StartCoroutine(_animator.PointAtoB(projectile.transform, position, _easeType, _animationDuration));
        
        projectile.GetComponent<FreezeProjectile>().Freeze();
    }
}
