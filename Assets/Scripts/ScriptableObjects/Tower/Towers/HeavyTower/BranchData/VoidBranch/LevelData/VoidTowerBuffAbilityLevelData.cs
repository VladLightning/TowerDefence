using UnityEngine;

[CreateAssetMenu(fileName = "VoidTowerBuffData", menuName = "AbilityLevelsData/VoidTowerBuff", order = 5)]

public class VoidTowerBuffAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private float[] _damageCoefficientBuff;
    public float[] DamageCoefficientBuff => _damageCoefficientBuff;
}
