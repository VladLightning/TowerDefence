using UnityEngine;

public class TowerStatsStructure 
{
    [System.Serializable]
    public struct TowerStats
    {
        [SerializeField] private GameObject _projectile;
        public GameObject Projectile => _projectile;

        [SerializeField] private Sprite _towerSprite;
        public Sprite TowerSprite => _towerSprite;

        [SerializeField] private float _range;
        public float Range => _range;

        [SerializeField] private float _shootingDelay;
        public float ShootingDelay => _shootingDelay;

        [SerializeField] private float _damage;
        public float Damage => _damage;

        [SerializeField] private int _price;
        public int Price => _price;

        [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
        public DamageTypeEnum.DamageTypes DamageType => _damageType;
    }
}
