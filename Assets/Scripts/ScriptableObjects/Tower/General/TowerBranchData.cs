using UnityEngine;
[CreateAssetMenu(fileName = "BranchData", menuName = "TowerBranch")]
public class TowerBranchData : TowerLevelsData
{
    [SerializeField] private Sprite _towerSprite;
    public Sprite TowerSprite => _towerSprite;

    [SerializeField] private BranchUpgradeData[] _branchUpgradesData;
    public BranchUpgradeData[] BranchUpgradesData => _branchUpgradesData;
}