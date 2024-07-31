using UnityEngine;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _towerToBuild;

    [SerializeField] private TowerManager _towerManager;

    public void OnClick()
    {       
        _towerManager.BuildTower(_towerToBuild);
    }
}
