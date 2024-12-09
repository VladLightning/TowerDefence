using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class CastleProjectileAbility : Ability
{
    [SerializeField] private GameObject _projectile;
    
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _animationDuration;
    
    private Transform _projectileSpawnPoint;
    private TweenAnimation _animator;
    
    protected abstract void InitProjectile(GameObject projectile);
    
    public void InitCastleProjectileAbility(Transform projectileSpawnPoint, TweenAnimation animator)
    {
        _projectileSpawnPoint = projectileSpawnPoint;
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
        yield return _animator.StartCoroutine(_animator.PointAtoB(projectile.transform, GetMousePosition(), _easeType, _animationDuration));
        
        projectile.GetComponent<IProjectile>().Explode();
    }
}
