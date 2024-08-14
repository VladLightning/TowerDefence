using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;
    [SerializeField] private TowerExampleData[] _towerStatsData;

    public GameObject GetTower(TowersEnum.TowerTypes type)
    {
        return _towers[(int)type];
    }

    public TowerExampleData GetStats(TowersEnum.TowerTypes type)
    {
        return _towerStatsData[(int)type];
    }
}