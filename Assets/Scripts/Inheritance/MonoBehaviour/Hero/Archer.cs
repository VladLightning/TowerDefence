
using UnityEngine;

public class Archer : Hero
{
    [SerializeField] private Transform _projectileLaunchPosition;
    
    private GameObject _rangedWeapon;
    private GameObject _meleeWeapon;
    
    private DefaultProjectileData _projectileData;
    
    private CombatStatesEnum.CombatStates _combatState;

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;

        _rangedWeapon = archerData.RangedWeapon;
        _meleeWeapon = archerData.MeleeWeapon;
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.CombatStates.Ranged;
    }

    public override void EnterCombat(Mob target)
    {
        _combatState = CombatStatesEnum.CombatStates.Melee;
        base.EnterCombat(target);
    }

    public override void ExitCombat()
    {
        _combatState = CombatStatesEnum.CombatStates.Ranged;
        base.ExitCombat();
    }

    private void Shoot()
    {
        var projectile = Instantiate(_projectileData.ProjectilePrefab, _projectileLaunchPosition.position, CalculateProjectileDirection()).GetComponent<Projectile>();
        projectile.Initialize(_projectileData.ProjectileLevels[0]);
    }

    private Quaternion CalculateProjectileDirection()
    {
        float y = Opponent.transform.position.y - _projectileLaunchPosition.position.y;
        float x = Opponent.transform.position.x - _projectileLaunchPosition.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        return Quaternion.Euler(0, 0, angle);
    }
}
