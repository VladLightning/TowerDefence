
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Status", order = 2)]
public class StatusProjectileData : ProjectileData
{
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