
using UnityEngine;

public class StatusProjectile : Projectile
{
    private StatusProjectileStats _statusProjectileStats;
    
    protected override void HitTarget(Collider2D collision)
    {
        collision.GetComponent<StatusEffects>().TriggerEffect(_statusProjectileStats, _damageType);
        base.HitTarget(collision);
    }
    
    public void Initialize(StatusProjectileStats statusProjectileStats, DamageTypesEnum.DamageTypes damageType)
    {
        _damageType = damageType;
        
        _statusProjectileStats = statusProjectileStats;
        
        _damage = statusProjectileStats.Damage;
        ProjectileFly(statusProjectileStats.Force);
    }
}
