using UnityEngine;

[CreateAssetMenu(fileName = "TowerStatsData", menuName = "Tower")]
public class TowerStatsData : ScriptableObject
{
    public GameObject _projectile;

    public Sprite _towerSprite;

    public float _shootingRange;

    public float _shootingDelay;

    public float _damage;

    public DamageTypeEnum.DamageTypes _damageType;

    public TowerStatsStructure.TowerStats _towerStats;
}
