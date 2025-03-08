using UnityEngine;
using UnityEngine.Serialization;

public abstract class TowerLevelsData : EntityData
{
    public const int MAX_TOWER_LEVEL = 3;
    
    [SerializeField] private ProjectileData _projectileData;
    public ProjectileData ProjectileData => _projectileData;

    [SerializeField] protected TowerLevels[] _towerLevels;
    public TowerLevels[] TowerLevels => _towerLevels;
}

[System.Serializable]
public class TowerLevels
{
    [SerializeField] private float _attackDelay;
    public float AttackDelay => _attackDelay;

    [SerializeField] private float _range;
    public float Range => _range;

    [SerializeField] private int _price;
    public int Price => _price;

    [SerializeField] private int _rotationSpeed;
    public int RotationSpeed => _rotationSpeed;
}