using UnityEngine;
public abstract class TowerData : EntityData
{
    [SerializeField] protected float _force;
    public float Force => _force;
    [SerializeField] protected float _range;
    public float Range => _range;

    [SerializeField] protected int _price;
    public int Price => _price;

    [SerializeField] protected int _rotationSpeed;
    public int RotationSpeed => _rotationSpeed;

    [SerializeField] protected TowerLevels[] towerLevels;
    public TowerLevels[] TowerLevels => towerLevels;
}

[System.Serializable]
public class TowerLevels
{
    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;

    [SerializeField] private float _force;
    public float Force => _force;

    [SerializeField] private float _range;
    public float Range => _range;

    [SerializeField] private int _price;
    public int Price => _price;

    [SerializeField] private int _rotationSpeed;
    public int RotationSpeed => _rotationSpeed;
}
