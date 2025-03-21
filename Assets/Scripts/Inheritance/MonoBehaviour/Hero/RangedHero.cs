
using System.Collections;
using UnityEngine;

public abstract class RangedHero : Hero
{ 
    [SerializeField] protected Transform _projectileLaunchPosition;
    protected RangedHeroDetectShootingTarget _rangedHeroDetectShootingTarget;
    
    protected ProjectileData _projectileData;

    private bool _shootingIsActive;
    public bool ShootingIsActive {
        get => _shootingIsActive;
        private set => _shootingIsActive = value;
    }

    protected virtual bool CanShoot => _rangedHeroDetectShootingTarget.TargetToShoot != null && 
                                       _currentState is MobStatesEnum.MobStates.Idle or MobStatesEnum.MobStates.Fighting;
    
    protected abstract ProjectileStats GetProjectileStats { get; }
    
    protected override void GetSkills()
    {
        _activeSkill = GetComponentInChildren<IActiveHeroSkill>();
        _passiveSkill = GetComponentInChildren<IPassiveHeroSkill>();
    }
    
    public IEnumerator Shoot()
    {
        ShootingIsActive = true;
        
        while (CanShoot)
        {
            _rangedHeroDetectShootingTarget.FindTarget();
            LookAtTarget(_rangedHeroDetectShootingTarget.TargetToShoot.position);
            
            yield return new WaitForSeconds(_attackDelay);
            
            if (!CanShoot)
            {
                ShootingIsActive = false;
                yield break;
            }
            
            _activeSkill.ActiveSkillTrigger();
            
            StartCoroutine(SpawnProjectile());
        }
        ShootingIsActive = false;
    }

    protected virtual IEnumerator SpawnProjectile()
    {
        yield return null;
        var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
        projectile.Initialize(GetProjectileStats, _damageCoefficient, _projectileData.DamageType);
    }

    protected override IEnumerator MoveHero(Vector2 targetPosition)
    {
        yield return base.MoveHero(targetPosition);
        _rangedHeroDetectShootingTarget.Collider2D.enabled = false;
        _rangedHeroDetectShootingTarget.Collider2D.enabled = true;
    }

    public Quaternion CalculateProjectileDirection()
    {
        float y = _rangedHeroDetectShootingTarget.TargetToShoot.transform.position.y - _projectileLaunchPosition.position.y;
        float x = _rangedHeroDetectShootingTarget.TargetToShoot.transform.position.x - _projectileLaunchPosition.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        return Quaternion.Euler(0, 0, angle);
    }
}
