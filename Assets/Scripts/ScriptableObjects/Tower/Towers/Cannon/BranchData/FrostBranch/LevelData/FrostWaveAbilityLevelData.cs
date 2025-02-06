
using UnityEngine;
[CreateAssetMenu(fileName = "FrostWaveData", menuName = "AbilityLevelsData/FrostWave", order = 3)]
public class FrostWaveAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField]private GameObject _frostWavePrefab;
    public GameObject FrostWavePrefab => _frostWavePrefab;
    
    [SerializeField] private FrostWaveStats[] _frostWaveLevels;
    public FrostWaveStats[] FrostWaveLevels => _frostWaveLevels;
    
    [System.Serializable]
    public struct FrostWaveStats
    {
        [SerializeField] private float _frostWaveRadius;
        public float FrostWaveRadius => _frostWaveRadius;
        
        [SerializeField] private float _frostWaveSpeedReduction;
        public float FrostWaveSpeedReduction => _frostWaveSpeedReduction;
        
        [SerializeField] private float _frostWaveSpeedReductionDuration;
        public float FrostWaveSpeedReductionDuration => _frostWaveSpeedReductionDuration;
        
        [SerializeField] private float _frostWaveInterval;
        public float FrostWaveInterval => _frostWaveInterval;
        
        [SerializeField] private float _frostWaveDuration;
        public float FrostWaveDuration => _frostWaveDuration;
    }
}
