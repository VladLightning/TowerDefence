using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    public static event Action<float, Transform> OnTowerSelected;
    public static event Action OnTowerDeselected;
    
    [SerializeField] private GameObject _towerUpgradePanel;
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
        
        AoEAbility.OnDisableRangedRadius += DisableTowerUpgradePanel;
    }

    private void OnDestroy()
    {
        MouseInput.OnTowerSelected -= EnableTowerUpgradePanel;
        MouseInput.OnNothingSelected -= ResetToDefaultState;
        
        AoEAbility.OnDisableRangedRadius -= DisableTowerUpgradePanel;
    }

    private void EnableTowerUpgradePanel(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex + 1].Price.ToString();

        ResetToDefaultState();

        transform.position = _tower.transform.position;
        
        _towerUpgradePanel.SetActive(true);
        OnTowerSelected?.Invoke(_tower.Range, _tower.transform);

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

    private void DisableTowerUpgradePanel()
    {
        _towerUpgradePanel.SetActive(false);
        OnTowerDeselected?.Invoke();
    }

    public void ResetToDefaultState()
    {
        _branchHandler.Disable();
        _branchUpgradesHandler.Disable();

        DisableTowerUpgradePanel();
        
        _upgradePanel.SetActive(true);
    }

    public void ExecuteTowerUpgrade()
    {
        if (_tower.IsMaxLevel())
        {
            return;
        }
        _tower.Upgrade();
        DisableTowerUpgradePanel();
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        DisableTowerUpgradePanel();
    }

    public void UpgradeButtonIsAvailable()
    {
        _upgradeButton.interactable = _tower.IsUpgradeAvailable();
    }

    public bool IsTowerUpgradePanelActive()
    {
        return _towerUpgradePanel.activeSelf;
    }
}
