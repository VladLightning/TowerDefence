
public class Mage : RangedHero
{
    private StatusProjectileData StatusProjectileData => _projectileData as StatusProjectileData;

    protected override ProjectileStats GetProjectileStats => StatusProjectileData.StatusProjectileStats[0];
    
    protected override void Initiate()
    {
        base.Initiate();
        var archerData = _entityData as MageData;
        
        _projectileData = archerData.ProjectileData;

        _rangedHeroDetectShootingTarget = GetComponentInChildren<RangedHeroDetectShootingTarget>();
    }
}