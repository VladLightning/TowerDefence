
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Status", order = 2)]
public class StatusProjectileData : ProjectileData
{
    [SerializeField] private DamageTypesEnum.DamageTypes _damageType;
    public DamageTypesEnum.DamageTypes DamageType => _damageType;
    
    [SerializeField] private StatusProjectileStats[] _statusProjectileStats;
    public StatusProjectileStats[] StatusProjectileStats => _statusProjectileStats;
}

[System.Serializable]
public class StatusProjectileStats : ProjectileStats
{
    [SerializeField] private int _statusDamage;
    public int StatusDamage => _statusDamage;
    
    [SerializeField] private int _statusTicksAmount;
    public int StatusTicksAmount => _statusTicksAmount;

    [SerializeField] private float _statusTickInterval;
    public float StatusTickInterval => _statusTickInterval;
}