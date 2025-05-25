using UnityEngine;

[CreateAssetMenu(fileName = "WindTowerPullData", menuName = "AbilityLevelsData/WindTowerPull", order = 8)]
public class WindTowerPullAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private PullData[] _pullStats;
    public PullData[] PullStats => _pullStats;

    [System.Serializable]
    public class PullData
    {
        [SerializeField] private float _pullForce;
        public float PullForce => _pullForce;
        [SerializeField] private float _pullInterval;
        public float PullInterval => _pullInterval;
    }
}
