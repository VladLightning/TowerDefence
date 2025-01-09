using UnityEngine;

public abstract class TowerLevelsData : EntityData
{
    public const int MAX_TOWER_LEVEL = 3;
    
    [SerializeField] private ProjectileData _projectileData;
    public ProjectileData ProjectileData => _projectileData;

    [SerializeField] protected TowerLevels[] towerLevels;
    public TowerLevels[] TowerLevels => towerLevels;
}

[System.Serializable]
public class TowerLevels
{
    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private float _range;
    public float Range => _range;

    [SerializeField] private int _price;
    public int Price => _price;

    [SerializeField] private int _rotationSpeed;
    public int RotationSpeed => _rotationSpeed;
}