using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _towerUpgradePanel;
    public GameObject MainTowerUpgradePanel => _towerUpgradePanel;
    [SerializeField] private GameObject _upgradePanel;

    [SerializeField] private BranchUpgradesHandler _branchUpgradesHandler;
    [SerializeField] private BranchHandler _branchHandler;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceDisplay; 

    private Tower _tower;

    private void Awake()
    {
        MouseInput.OnTowerSelected += EnableTowerUpgradePanel;
        MouseInput.OnNothingSelected += ResetToDefaultState;
    }

    private void OnDestroy()
    {
        MouseInput.OnTowerSelected -= EnableTowerUpgradePanel;
        MouseInput.OnNothingSelected -= ResetToDefaultState;
    }

    private void EnableTowerUpgradePanel(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex].Price.ToString();

        ResetToDefaultState();

        transform.position = _tower.transform.position;
        _towerUpgradePanel.SetActive(true);

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

        _towerUpgradePanel.SetActive(false);
        
        _upgradePanel.SetActive(true);
    }

    public void ExecuteTowerUpgrade()
    {
        if (_tower.IsMaxLevel())
        {
            return;
        }
        _tower.Upgrade();
        _towerUpgradePanel.SetActive(false);
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        _towerUpgradePanel.SetActive(false);
    }

    public void UpgradeButtonIsAvailable()
    {
        _upgradeButton.interactable = _tower.IsUpgradeAvailable();
    }
}
