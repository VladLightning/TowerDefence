
using UnityEngine;

[CreateAssetMenu(fileName = "FrostTowerBuffData", menuName = "AbilityLevelsData/FrostTowerBuff", order = 4)]

public class FrostTowerBuffAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private FrostTowerBuffStats[] _frostTowerBuffLevels;
    public FrostTowerBuffStats[] FrostTowerBuffLevels => _frostTowerBuffLevels;
    
    [System.Serializable]
    public struct FrostTowerBuffStats
    {
        [SerializeField] private float _damageCoefficientBuff;
        public float DamageCoefficientBuff => _damageCoefficientBuff;
        
        [SerializeField] private float _attackDelayCoefficientBuff;
        public float AttackDelayCoefficientBuff => _attackDelayCoefficientBuff;
    }
}
