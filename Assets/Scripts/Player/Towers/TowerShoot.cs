using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    private TowerStatsStructure.TowerStats _towerStats;

    public void Initialize(TowerStatsData towerStats)
    {
        _towerStats._projectile = towerStats.Projectile;
        _towerStats._towerSprite = towerStats.TowerSprite;
        _towerStats._shootingRange = towerStats.ShootingRange;
        _towerStats._shootingDelay = towerStats.ShootingDelay;
        _towerStats._damage = towerStats.Damage;
        _towerStats._damageType = towerStats.DamageType;
    }
}
