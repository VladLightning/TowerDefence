using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Default", order = 1)]
public class DefaultProjectileData : ProjectileData
{
    [SerializeField] private ProjectileStats[] _projectileStats;
    public ProjectileStats[] ProjectileStats => _projectileStats;
}
