using UnityEngine;

public class StatusProjectile : Projectile
{
    private StatusProjectileStats _statusProjectileStats;
    
    protected override void HitTarget(Collider2D collision)
    {
        collision.GetComponent<StatusEffects>().TriggerEffect(_statusProjectileStats, _damageType);
        base.HitTarget(collision);
    }
    
    public override void Initialize(ProjectileStats projectileStats, float damageCoefficient, DamageTypesEnum.DamageTypes damageType = DamageTypesEnum.DamageTypes.Physical)
    {
        var statusProjectileStats = projectileStats as StatusProjectileStats;
        _statusProjectileStats = statusProjectileStats;
        
        base.Initialize(statusProjectileStats, damageCoefficient, damageType);
    }
}
