using UnityEngine;
public class CastleCannonShotAbility : CastleProjectileAbility
{
    protected override void InitProjectile(GameObject projectile)
    {
        var castleCannonShotProjectile = projectile.GetComponent<CastleCannonShotProjectile>();
        var abilityData = _abilityData as CastleCannonAbilityData;
        
        castleCannonShotProjectile.InitProjectile(abilityData.Mask, abilityData.ExplosionForce, abilityData.ExplosionRadius, abilityData.ExplosionDamage);
    }
}
