using UnityEngine;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] private Towers _towers;
    [SerializeField] private TowersEnum.TowerTypes _towerType;

    [SerializeField] private TowerManager _towerManager;

    public void OnClick()
    {       
        _towers.TowerType = _towerType;
        _towerManager.BuildTower(_towers.Tower);
    }
}
