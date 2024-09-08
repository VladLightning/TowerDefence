using UnityEngine;
[CreateAssetMenu(fileName = "BranchData", menuName = "TowerBranch")]
public class TowerBranchData : ScriptableObject
{
    public const int MAX_BRANCH_LEVEL = 3;

    [SerializeField] private Sprite _towerSprite;
    public Sprite TowerSprite => _towerSprite;

    [SerializeField] private GameObject _projectile;
    public GameObject Projectile => _projectile;

    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;

    [SerializeField] private BranchLevels[] _branchLevels;
    public BranchLevels[] BranchLevels => _branchLevels;
}
[System.Serializable]
public class BranchLevels
{
    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private float _force;
    public float Force => _force;

    [SerializeField] private float _range;
    public float Range => _range;

    [SerializeField] private int _rotationSpeed;
    public int RotationSpeed => _rotationSpeed;
}
