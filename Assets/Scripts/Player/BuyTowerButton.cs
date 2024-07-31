using UnityEngine;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _towerToBuild;

    [SerializeField] private TowerManager _choicePanel;

    public void OnClick()
    {       
        _choicePanel.BuildTower(_towerToBuild);
    }
}
