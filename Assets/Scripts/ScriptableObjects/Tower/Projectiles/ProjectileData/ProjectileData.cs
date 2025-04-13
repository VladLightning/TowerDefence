using UnityEngine;

public abstract class ProjectileData : BranchLevelsUpgradeData
{
    [SerializeField] private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab => _projectilePrefab;
    [SerializeField] private DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;
}

[System.Serializable]
public class ProjectileStats
{
    [SerializeField] private int _damage;
    public int Damage => _damage;
    
    [SerializeField] private float _force;
    public float Force => _force;
}