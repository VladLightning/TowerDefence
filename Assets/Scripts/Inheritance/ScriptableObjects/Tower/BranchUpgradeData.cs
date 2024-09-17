using UnityEngine;
[CreateAssetMenu(fileName = "BranchUpgrades", menuName = "UpgradesData")]
public class BranchUpgradeData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private BranchUpgrades[] _branchUpgrades;
    public BranchUpgrades[] BranchUpgrades => _branchUpgrades;
}

[System.Serializable] 
public class BranchUpgrades
{
    [SerializeField] private int _price;
    public int Price => _price;
}