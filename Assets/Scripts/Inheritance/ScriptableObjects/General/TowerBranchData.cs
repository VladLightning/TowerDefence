using UnityEngine;
[CreateAssetMenu(fileName = "BranchData", menuName = "TowerBranch")]
public class TowerBranchData : TowerData
{
    [SerializeField] private Sprite _towerSprite;
    public Sprite TowerSprite => _towerSprite;
}