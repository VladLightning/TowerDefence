using DG.Tweening;
using UnityEngine;

public class DefaultAbility : Ability
{
    [SerializeField] private GameObject _projectile;

    [SerializeField] private Ease _easeType;
    [SerializeField] private float _animationDuration;
    
    private Transform _projectileSpawnPoint;
    
    private TweenAnimation _animator;

    public void InitDefaultAbility(Transform projectileSpawnPoint, TweenAnimation animator)
    {
        _projectileSpawnPoint = projectileSpawnPoint;
        _animator = animator;
    }

    protected override void AbilityCast(Vector3 position)
    {
        base.AbilityCast(position);
        GameObject projectile = Instantiate(_projectile, _projectileSpawnPoint.position, _projectile.transform.rotation);
        _animator.StartCoroutine(_animator.PointAtoB(projectile.transform, position, _easeType, _animationDuration));
    }
}
