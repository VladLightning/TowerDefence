using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private PlayerMoney _playerMoney;
    private Tower _tower;
    public Tower Tower => _tower;

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeIsAvailableCheck();

        Disable();
        transform.position = _tower.transform.position;
        gameObject.SetActive(true); 
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void ExecuteTowerUpgrade()
    {
        _tower.Upgrade();
        gameObject.SetActive(false);
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        gameObject.SetActive(false);
    }

    public void UpgradeIsAvailableCheck()
    {
        _upgradeButton.interactable = _tower.TowerLevels[_tower.TowerLevelIndex].Price <= _playerMoney.MoneyAmount;
    }
}
