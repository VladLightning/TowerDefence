using UnityEngine;
[CreateAssetMenu(fileName = "BranchData", menuName = "TowerBranch")]
public class TowerBranchData : ScriptableObject
{
    [SerializeField] private Sprite _towerSprite;
    public Sprite TowerSprite => _towerSprite;

    [SerializeField] private GameObject _projectile;
    public GameObject Projectile => _projectile;

    [SerializeField] private DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;

    [SerializeField] private int _price;
    public int Price => _price;
}