using UnityEngine;

[CreateAssetMenu(fileName = "WindTowerBuffData", menuName = "AbilityLevelsData/WindTowerBuff", order = 6)]

public class WindTowerBuffAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private float[] _attackDelayCoefficientBuff;
    public float[] AttackDelayCoefficientBuff => _attackDelayCoefficientBuff;
}
