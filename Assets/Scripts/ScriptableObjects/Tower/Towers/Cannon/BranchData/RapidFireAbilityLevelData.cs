
using UnityEngine;
[CreateAssetMenu(fileName = "RapidFireData", menuName = "SpecialShootingLevelsData/RapidFire", order = 2)]
public class RapidFireAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private RapidFireStats[] _specialShootingStats;
    public RapidFireStats[] SpecialShootingStats => _specialShootingStats;
}

[System.Serializable]
public class RapidFireStats
{
    [SerializeField] private int _specialShotsCapacity;
    public int SpecialShotsCapacity => _specialShotsCapacity;
    
    [SerializeField] private float _specialShotInterval;
    public float SpecialShotInterval => _specialShotInterval;

    [SerializeField] private float _specialShotLoadTime;
    public float SpecialShotLoadTime => _specialShotLoadTime;
}
