using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceDisplay;
    private Tower _tower;

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex].Price.ToString();

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
        if(!_tower.IsMaxLevel())
        {
            _tower.Upgrade();
            gameObject.SetActive(false);
        }
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        gameObject.SetActive(false);
    }

    public void UpgradeButtonIsAvailable()
    {
        if(_tower == null)
        {
            return;
        }
        _upgradeButton.interactable = _tower.IsUpgradeAvailable();
    }
}
