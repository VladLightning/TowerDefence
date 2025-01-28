
using UnityEngine;

public abstract class SpecialShootingAbilityData : BranchLevelsUpgradeData
{
    [SerializeField] private SpecialShootingStats[] _specialShootingStats;
    public SpecialShootingStats[] SpecialShootingStats => _specialShootingStats;
}

[System.Serializable]
public class SpecialShootingStats
{
    [SerializeField] private int _specialShotsCapacity;
    public int SpecialShotsCapacity => _specialShotsCapacity;
    
    [SerializeField] private float _specialShotInterval;
    public float SpecialShotInterval => _specialShotInterval;

    [SerializeField] private float _specialShotLoadTime;
    public float SpecialShotLoadTime => _specialShotLoadTime;
}
