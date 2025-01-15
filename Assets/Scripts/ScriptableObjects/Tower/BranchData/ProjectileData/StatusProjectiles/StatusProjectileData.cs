
using UnityEngine;
[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Status", order = 2)]
public class StatusProjectileData : ProjectileData
{
    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;
    
    [SerializeField] private StatusProjectileStats[] _statusProjectileStats;
    public StatusProjectileStats[] StatusProjectileStats => _statusProjectileStats;
}

[System.Serializable]
public class StatusProjectileStats : ProjectileStats
{
    [SerializeField] private int _statusDamage;
    public int StatusDamage => _statusDamage;
    
    [SerializeField] private float _statusTick;
    public float StatusTick => _statusTick;
}