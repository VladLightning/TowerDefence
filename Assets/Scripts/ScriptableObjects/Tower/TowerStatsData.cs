using UnityEngine;

[CreateAssetMenu(fileName = "TowerStatsData", menuName = "Tower")]
public class TowerStatsData : ScriptableObject
{
    [SerializeField] private TowerStatsStructure.TowerStats _towerStats;
    public TowerStatsStructure.TowerStats TowerStats => _towerStats;
}