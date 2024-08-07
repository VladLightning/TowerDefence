using UnityEngine;

public class TowerStatsStructure 
{
    public struct TowerStats
    {
        public GameObject _projectile;

        public Sprite _towerSprite;

        public float _shootingRange;

        public float _shootingDelay;

        public float _damage;

        public DamageTypeEnum.DamageTypes _damageType;
    }
}
