
using UnityEngine;
[CreateAssetMenu(fileName = "RapidFireData", menuName = "RapidFireUpgrade", order = 2)]
public class RapidFireAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private RapidFireStats[] _rapidFireStats;
    public RapidFireStats[] RapidFireStats => _rapidFireStats;
}

[System.Serializable]
public class RapidFireStats
{
    [SerializeField] private int _capacity;
    public int Capacity => _capacity;
    
    [SerializeField] private float _rapidShotInterval;
    public float RapidShotInterval => _rapidShotInterval;

    [SerializeField] private float _rapidShotLoadTime;
    public float RapidShotLoadTime => _rapidShotLoadTime;
}