
using UnityEngine;

public class StatusProjectileData : BranchUpgradeData
{
    public override string UpgradeClassName { get; }

    [SerializeField] private ProjectileData _projectileData;
    public ProjectileData ProjectileData => _projectileData;
    
    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;
    
    [SerializeField] private int _statusEffectDamage;
    public int StatusEffectDamage => _statusEffectDamage;
    
    [SerializeField] private float _statusEffectDuration;
    public float StatusEffectDuration => _statusEffectDuration;
}
