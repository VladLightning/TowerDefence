
using UnityEngine;
[CreateAssetMenu(fileName = "RapidFireData", menuName = "AbilityLevelsData/RapidFire", order = 1)]
public class RapidFireAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private RapidFireStats[] _rapidFireLevels;
    public RapidFireStats[] RapidFireLevels => _rapidFireLevels;
    
    [System.Serializable]
    public struct RapidFireStats
    {
        [SerializeField] private int _rapidShotsCapacity;
        public int RapidShotsCapacity => _rapidShotsCapacity;
    
        [SerializeField] private float _rapidShotInterval;
        public float RapidShotInterval => _rapidShotInterval;

        [SerializeField] private float _rapidShotLoadTime;
        public float RapidShotLoadTime => _rapidShotLoadTime;
    }
}
