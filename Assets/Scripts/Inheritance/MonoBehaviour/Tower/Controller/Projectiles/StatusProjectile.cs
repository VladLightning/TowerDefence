
using UnityEngine;

public class StatusProjectile : Projectile
{
    protected int _statusEffectDamage;
    protected float _statusEffectDuration;
    
    protected override void TriggerEffect(Collider2D collision)
    {
        //Базовый статусный проджектайл
    }
    
    public void Initialize(StatusProjectileData statusProjectileData)
    {
        _damageType = statusProjectileData.DamageType;
        _statusEffectDamage = statusProjectileData.StatusEffectDamage;
        _statusEffectDuration = statusProjectileData.StatusEffectDuration;
        
        _damage = statusProjectileData.ProjectileData.ProjectileLevels[0].Damage;
        ProjectileFly(statusProjectileData.ProjectileData.ProjectileLevels[0].Force);
    }
}
