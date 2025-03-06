
using System.Collections;
using UnityEngine;

public class Archer : Hero
{
    [SerializeField] private Transform _projectileLaunchPosition;
    
    private GameObject _rangedWeapon;
    private GameObject _meleeWeapon;
    
    private DefaultProjectileData _projectileData;
    
    private CombatStatesEnum.CombatStates _combatState;

    private IEnumerator _shoot;

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;

        _rangedWeapon = archerData.RangedWeapon;
        _meleeWeapon = archerData.MeleeWeapon;
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.CombatStates.Ranged;

        _shoot = Shoot();
    }
    

    public override void EnterCombat(Mob target)
    {
        base.EnterCombat(target);
        StartCoroutine(_shoot);
    }

    public override void ExitCombat()
    {
        _combatState = CombatStatesEnum.CombatStates.Ranged;
        _shoot = Shoot();
        base.ExitCombat();
    }
    
    private IEnumerator Shoot()
    {
        while (_combatState == CombatStatesEnum.CombatStates.Ranged)
        {
            yield return new WaitForSeconds(_attackSpeed);
            var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
            projectile.Initialize(_projectileData.ProjectileLevels[0]);
        }
    }

    private Quaternion CalculateProjectileDirection()
    {
        float y = Opponent.transform.position.y - _projectileLaunchPosition.position.y;
        float x = Opponent.transform.position.x - _projectileLaunchPosition.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        return Quaternion.Euler(0, 0, angle);
    }
}
