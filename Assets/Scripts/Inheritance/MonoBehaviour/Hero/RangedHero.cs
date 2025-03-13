
using System.Collections;
using UnityEngine;

public abstract class RangedHero : Hero
{ 
    [SerializeField] protected Transform _projectileLaunchPosition;
    protected RangedHeroDetectShootingTarget _rangedHeroDetectShootingTarget;
    
    protected ProjectileData _projectileData;

    private float _damageCoefficient = 1;

    private bool _shootingIsActive;
    public bool ShootingIsActive {
        get => _shootingIsActive; 
        protected set => _shootingIsActive = value;
    }
    
    protected virtual bool IsHeroIdle => _currentState == MobStatesEnum.MobStates.Idle;
    protected virtual bool IsTargetLost => _rangedHeroDetectShootingTarget.TargetToShoot == null;
    
    protected abstract ProjectileStats GetProjectileStats { get; }
    
    protected override void GetSkills()
    {
        _activeSkill = GetComponentInChildren<IActiveHeroSkill>();
        _passiveSkill = GetComponentInChildren<IPassiveHeroSkill>();
    }
    
    public IEnumerator Shoot()
    {
        ShootingIsActive = true;
        
        while (IsHeroIdle)
        {
            _rangedHeroDetectShootingTarget.FindTarget();
            LookAtTarget(_rangedHeroDetectShootingTarget.TargetToShoot.position);
            
            yield return new WaitForSeconds(_attackDelay);
            
            if (IsTargetLost)
            {
                ShootingIsActive = false;
                yield break;
            }
            
            _activeSkill.ActiveSkillTrigger();
            
            var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
            projectile.Initialize(GetProjectileStats, _damageCoefficient);
        }
        ShootingIsActive = false;
    }

    private Quaternion CalculateProjectileDirection()
    {
        float y = _rangedHeroDetectShootingTarget.TargetToShoot.transform.position.y - _projectileLaunchPosition.position.y;
        float x = _rangedHeroDetectShootingTarget.TargetToShoot.transform.position.x - _projectileLaunchPosition.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        return Quaternion.Euler(0, 0, angle);
    }
}
