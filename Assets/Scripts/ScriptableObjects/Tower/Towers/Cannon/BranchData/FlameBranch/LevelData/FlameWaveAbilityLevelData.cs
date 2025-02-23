
using UnityEngine;

[CreateAssetMenu(fileName = "FlameWaveData", menuName = "AbilityLevelsData/FlameWave", order = 2)]

public class FlameWaveAbilityLevelData : DamageDealingLevelsUpgradeData
{
    [SerializeField]private GameObject _flameWavePrefab;
    public GameObject FlameWavePrefab => _flameWavePrefab;
    
    [SerializeField] private FlameWaveStats[] _flameWaveLevels;
    public FlameWaveStats[] FlameWaveLevels => _flameWaveLevels;
    
    [System.Serializable]
    public struct FlameWaveStats
    {
        [SerializeField] private float _flameWaveReloadTime;
        public float FlameWaveReloadTime => _flameWaveReloadTime;
        
        [SerializeField] private float _flameWaveDuration;
        public float FlameWaveDuration => _flameWaveDuration;
        
        [SerializeField] private float _flameWaveSpeed;
        public float FlameWaveSpeed => _flameWaveSpeed;
        
        [SerializeField] private int _flameWaveDamage;
        public int FlameWaveDamage => _flameWaveDamage;
    }
}
