using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;
    [SerializeField] private TowerStatsData[] _towerStatsData;

    public GameObject GetTower(TowersEnum.TowerTypes type)
    {
        return _towers[(int)type];
    }

    public TowerStatsData GetStats(TowersEnum.TowerTypes type)
    {
        return _towerStatsData[(int)type];
    }
}