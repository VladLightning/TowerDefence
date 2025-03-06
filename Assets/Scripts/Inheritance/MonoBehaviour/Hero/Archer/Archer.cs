
using System.Collections;
using UnityEngine;

public class Archer : Hero
{
    [SerializeField] private Transform _weaponHoldingPosition;
    
    private Transform _projectileLaunchPosition;
    
    private GameObject _rangedWeapon;
    private GameObject _meleeWeapon;
    
    private DefaultProjectileData _projectileData;
    
    private ArcherDetectShootingTarget _archerDetectShootingTarget;
    
    private CombatStatesEnum.CombatStates _combatState;

    public bool ShootingIsActive { get; private set; }

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;

        _rangedWeapon = Instantiate(archerData.RangedWeapon, _weaponHoldingPosition);
        _projectileLaunchPosition = _rangedWeapon.transform.GetChild(0).transform;
        
        _meleeWeapon = Instantiate(archerData.MeleeWeapon, _weaponHoldingPosition);
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.CombatStates.Ranged;
        _meleeWeapon.SetActive(false);

        _archerDetectShootingTarget = GetComponentInChildren<ArcherDetectShootingTarget>();
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
        _rangedWeapon.SetActive(false);
        _meleeWeapon.SetActive(true);
    }

    private void SetRangedCombatState()
    {
        _combatState = CombatStatesEnum.CombatStates.Ranged;
        _meleeWeapon.SetActive(false);
        _rangedWeapon.SetActive(true);
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
            
            yield return new WaitForSeconds(_attackSpeed);
            
            if (_archerDetectShootingTarget.TargetToShoot == null || _combatState == CombatStatesEnum.CombatStates.Melee)
            {
                ShootingIsActive = false;
                yield break;
            }
            
            var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
            projectile.Initialize(_projectileData.ProjectileLevels[0]);
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
