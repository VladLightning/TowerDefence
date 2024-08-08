using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    private TowerStatsStructure.TowerStats _towerStats;

    public void Initialize(TowerStatsData towerStats)
    {
        _towerStats = towerStats.TowerStats;
    }
}
