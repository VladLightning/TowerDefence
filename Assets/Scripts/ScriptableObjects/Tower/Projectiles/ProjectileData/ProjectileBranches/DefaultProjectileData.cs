using UnityEngine;
[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Default", order = 1)]
public class DefaultProjectileData : ProjectileData
{
    [SerializeField] private ProjectileStats[] _projectileLevels;
    public ProjectileStats[] ProjectileLevels => _projectileLevels;
}
