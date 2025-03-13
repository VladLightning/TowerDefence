
using System.Collections;
using UnityEngine;

public class Archer : RangedHero
{
    [SerializeField] private SpriteRenderer _weaponRenderer;
    
    private Sprite _rangedWeapon;
    private Sprite _meleeWeapon;
    
    private CombatStatesEnum.CombatStates _combatState;
    
    protected override bool IsHeroIdle => _combatState == CombatStatesEnum.CombatStates.Ranged && base.IsHeroIdle;
    protected override bool IsTargetLost => base.IsTargetLost || _combatState == CombatStatesEnum.CombatStates.Melee;
    private DefaultProjectileData DefaultProjectileData => _projectileData as DefaultProjectileData;

    protected override ProjectileStats GetProjectileStats => DefaultProjectileData.ProjectileStats[0];

    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as ArcherData;
        
        _projectileData = archerData.ProjectileData;
        
        _combatState = CombatStatesEnum.CombatStates.Ranged;

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
        _rangedHeroDetectShootingTarget.Collider2D.enabled = false;
        _rangedHeroDetectShootingTarget.Collider2D.enabled = true;
    }
}
