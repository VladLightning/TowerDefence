using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;

    [SerializeField] private BranchUpgradesHandler _branchUpgradesHandler;
    [SerializeField] private BranchHandler _branchHandler;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceDisplay; 

    private Tower _tower;

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex].Price.ToString();

        ResetToDefaultState();

        transform.position = _tower.transform.position;
        gameObject.SetActive(true);

        if (!_tower.IsMaxLevel())
        {
            return;
        }
        if (_tower.CurrentTowerBranchData == null)
        {
            _branchHandler.SetBranchChoice(_tower);
        }
        else
        {          
            _branchUpgradesHandler.Enable(_tower);
        }
        _upgradePanel.SetActive(false);
    }

    public void ResetToDefaultState()
    {
        _branchHandler.Disable();
        _branchUpgradesHandler.Disable();

        gameObject.SetActive(false);
        
        _upgradePanel.SetActive(true);
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
