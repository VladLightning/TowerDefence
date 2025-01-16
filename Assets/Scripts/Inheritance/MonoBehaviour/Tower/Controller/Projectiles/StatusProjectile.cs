
using UnityEngine;

public class StatusProjectile : Projectile
{
    protected int _statusEffectDamage;
    protected float _statusEffectDuration;
    
    protected override void TriggerEffect(Collider2D collision)
    {
        //Базовый статусный проджектайл
    }
    
    public void Initialize(StatusProjectileStats statusProjectileStats, DamageTypeEnum.DamageTypes damageType)
    {
        _damageType = damageType;
        _statusEffectDamage = statusProjectileStats.StatusDamage;
        _statusEffectDuration = statusProjectileStats.StatusTick;
        
        _damage = statusProjectileStats.Damage;
        ProjectileFly(statusProjectileStats.Force);
    }
}
