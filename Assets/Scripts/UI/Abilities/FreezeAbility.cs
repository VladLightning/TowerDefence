using UnityEngine;

public class FreezeAbility : CastleProjectileAbility
{
    protected override void InitProjectile(GameObject projectile)
    {
        var freezeProjectile = projectile.GetComponent<FreezeProjectile>();
        var abilityData = _abilityData as FreezeAbilityData;
        
        freezeProjectile.SetProjectileStats(abilityData.Mask, abilityData.Radius, abilityData.MovementSpeedReductionCoefficient, abilityData.FreezeDuration);
    }
}
