using UnityEngine;
public class BuyTowerButton : MonoBehaviour
{  
    [SerializeField] private TowersEnum.TowerTypes _towerType;

    [SerializeField] private TowerManager _towerManager;

    public void OnClick()
    {       
        _towerManager.BuildTower(_towerType);
    }
}
