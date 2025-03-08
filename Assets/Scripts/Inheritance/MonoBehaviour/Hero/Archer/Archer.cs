
using System.Collections;
using UnityEngine;

public class Archer : Hero
{
    [SerializeField] private Transform _weaponHoldingPosition;
    [SerializeField] private SpriteRenderer _weaponRenderer;
    [SerializeField] private Transform _projectileLaunchPosition;
    
    private Sprite _rangedWeapon;
    private Sprite _meleeWeapon;
    
    private DefaultProjectileData _projectileData;
    
    private ArcherDetectShootingTarget _archerDetectShootingTarget;
    
    private CombatStatesEnum.CombatStates _combatState;
    
    private float _damageCoefficient = 1;

    public bool ShootingIsActive { get; private set; }

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.CombatStates.Ranged;

        _rangedWeapon = archerData.RangedWeapon;
        _meleeWeapon = archerData.MeleeWeapon;

        _weaponRenderer.sprite = _rangedWeapon;

        _archerDetectShootingTarget = GetComponentInChildren<ArcherDetectShootingTarget>();
    }

    protected override void GetSkills()
    {
        _activeSkill = GetComponentInChildren<IActiveHeroSkill>();
        _passiveSkill = GetComponentInChildren<IPassiveHeroSkill>();
    }

    public override void EnterCombat(Mob target)
    {
        SetMeleeCombatState();
        base.EnterCombat(target);
    }
    
    public override void ExitCombat()
    {
        SetRangedCombatState();
        base.ExitCombat();
    }
    
    private void SetMeleeCombatState()
    {
        _combatState = CombatStatesEnum.CombatStates.Melee;
        _weaponRenderer.sprite = _meleeWeapon;
    }

    private void SetRangedCombatState()
    {
        _combatState = CombatStatesEnum.CombatStates.Ranged;
        _weaponRenderer.sprite = _rangedWeapon;
    }

    protected override IEnumerator MoveHero(Vector2 targetPosition)
    {
        yield return base.MoveHero(targetPosition);
        _archerDetectShootingTarget.Collider2D.enabled = false;
        _archerDetectShootingTarget.Collider2D.enabled = true;
    }
        
    public IEnumerator Shoot()
    {
        ShootingIsActive = true;
        while (_combatState == CombatStatesEnum.CombatStates.Ranged && _currentState == MobStatesEnum.MobStates.Idle)
        {
            _archerDetectShootingTarget.FindTarget();
            LookAtTarget(_archerDetectShootingTarget.TargetToShoot.position);
            
            yield return new WaitForSeconds(_attackDelay);
            
            if (_archerDetectShootingTarget.TargetToShoot == null || _combatState == CombatStatesEnum.CombatStates.Melee)
            {
                ShootingIsActive = false;
                yield break;
            }
            
            var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
            projectile.Initialize(_projectileData.ProjectileLevels[0], _damageCoefficient);
        }
        ShootingIsActive = false;
    }

    private Quaternion CalculateProjectileDirection()
    {
        float y = _archerDetectShootingTarget.TargetToShoot.transform.position.y - _projectileLaunchPosition.position.y;
        float x = _archerDetectShootingTarget.TargetToShoot.transform.position.x - _projectileLaunchPosition.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        return Quaternion.Euler(0, 0, angle);
    }
   
}
