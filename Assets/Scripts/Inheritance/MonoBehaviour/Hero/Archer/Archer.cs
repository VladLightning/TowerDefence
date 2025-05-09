
using UnityEngine;

public class Archer : RangedHero
{
    [SerializeField] private SpriteRenderer _weaponRenderer;
    
    private Sprite _rangedWeapon;
    private Sprite _meleeWeapon;
    
    private CombatStatesEnum _combatState;
    
    protected override bool CanShoot => _combatState == CombatStatesEnum.Ranged && _currentState == MobStatesEnum.Idle 
        && _rangedHeroDetectShootingTarget.TargetToShoot != null;
    private DefaultProjectileData DefaultProjectileData => _projectileData as DefaultProjectileData;

    protected override ProjectileStats GetProjectileStats => DefaultProjectileData.ProjectileStats[0];

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.Ranged;

        _rangedWeapon = archerData.RangedWeapon;
        _meleeWeapon = archerData.MeleeWeapon;

        _weaponRenderer.sprite = _rangedWeapon;

        _rangedHeroDetectShootingTarget = GetComponentInChildren<RangedHeroDetectShootingTarget>();
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
        _combatState = CombatStatesEnum.Melee;
        _weaponRenderer.sprite = _meleeWeapon;
    }

    private void SetRangedCombatState()
    {
        _combatState = CombatStatesEnum.Ranged;
        _weaponRenderer.sprite = _rangedWeapon;
    }
}
