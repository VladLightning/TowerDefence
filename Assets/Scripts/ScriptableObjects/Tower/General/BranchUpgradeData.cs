using UnityEngine;

public abstract class BranchUpgradeData : ScriptableObject
{
    public abstract string UpgradeClassName { get; }
    
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
    
    [SerializeField] private BranchLevelsUpgradeData _branchLevelsUpgradeData;
    public BranchLevelsUpgradeData BranchLevelsUpgradeData => _branchLevelsUpgradeData;

    [SerializeField] private int[] _upgradePrices;
    public int[] UpgradePrices => _upgradePrices;
    
    [SerializeField] private string _upgradeDescription;
    public string UpgradeDescription => _upgradeDescription;
}
