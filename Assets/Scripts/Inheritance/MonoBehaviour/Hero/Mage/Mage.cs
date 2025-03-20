
using System.Collections;
using UnityEngine;

public class Mage : RangedHero
{
    private readonly float _passiveSkillDelay = 0.1f;
    
    private StatusProjectileData StatusProjectileData => _projectileData as StatusProjectileData;

    protected override ProjectileStats GetProjectileStats => StatusProjectileData.StatusProjectileStats[0];
    
    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as MageData;
        
        _projectileData = archerData.ProjectileData;

        _rangedHeroDetectShootingTarget = GetComponentInChildren<RangedHeroDetectShootingTarget>();
    }

    protected override IEnumerator SpawnProjectile()
    {
        yield return base.SpawnProjectile();
        
        yield return new WaitForSeconds(_passiveSkillDelay);
        _passiveSkill.Activate();
    }
}