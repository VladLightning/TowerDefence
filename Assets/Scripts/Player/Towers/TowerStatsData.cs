using UnityEngine;

[CreateAssetMenu(fileName = "TowerStatsData", menuName = "Tower")]
public class TowerStatsData : ScriptableObject
{
    [SerializeField] private GameObject _projectile;
    public GameObject Projectile => _projectile;

    [SerializeField] private Sprite _towerSprite;
    public Sprite TowerSprite => _towerSprite;

    [SerializeField] private float _shootingRange;
    public float ShootingRange => _shootingRange;

    [SerializeField] private float _shootingDelay;
    public float ShootingDelay => _shootingDelay;

    [SerializeField] private float _damage;
    public float Damage => _damage;

    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;
}