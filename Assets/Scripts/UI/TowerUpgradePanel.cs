using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private BranchHandler _branchHandler;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceDisplay; 

    private Tower _tower;

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex].Price.ToString();

        Disable();

        if(_tower.IsMaxLevel())
        {
            _branchHandler.SetBranchChoice(_tower);
        }

        transform.position = _tower.transform.position;
        gameObject.SetActive(true); 
    }

    public void Disable()
    {
        _branchHandler.Disable();
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
        _upgradeButton.interactable = _tower.IsUpgradeAvailable();
    }
}
