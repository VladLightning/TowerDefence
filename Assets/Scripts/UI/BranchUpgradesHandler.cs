using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BranchUpgradesHandler : MonoBehaviour
{
    [SerializeField] private Button[] _upgradeButtons;
    [SerializeField] private PlayerMoney _playerMoney;

    private Tower _tower;
    private BranchUpgradeData[] _branchUpgradesData;

    private void UpdateLevelDisplay(int index)
    {
        _upgradeButtons[index].GetComponentInChildren<TMP_Text>().text =
        $"{_tower.CurrentBranchUpgradeLevels[index]} / {_branchUpgradesData[index].BranchUpgrades.Length}";
    }

    public void Enable(Tower tower)
    {
        gameObject.SetActive(true);

        _tower = tower;
        _branchUpgradesData = _tower.CurrentTowerBranchData.BranchUpgradesData;

        UpgradeButtonIsAvailable();

        for(int i = 0; i < _branchUpgradesData.Length; i++)
        {
            _upgradeButtons[i].image.sprite = _branchUpgradesData[i].Sprite;
            UpdateLevelDisplay(i);
        }
    }

    public void UpgradeButtonIsAvailable()
    {      
        for (int i = 0; i < _upgradeButtons.Length; i++)
        {
            var branchUpgrades = _branchUpgradesData[i].BranchUpgrades;
            if (branchUpgrades.Length <= _tower.CurrentBranchUpgradeLevels[i])
            {
                continue;
            }        
            _upgradeButtons[i].interactable = branchUpgrades[_tower.CurrentBranchUpgradeLevels[i]].Price <= _playerMoney.MoneyAmount;
        }
    }

    public void Upgrade(int upgradeIndex)
    {
        var branchUpgrades = _branchUpgradesData[upgradeIndex].BranchUpgrades;

        _playerMoney.Purchase(branchUpgrades[_tower.CurrentBranchUpgradeLevels[upgradeIndex]].Price);

        _tower.CurrentBranchUpgradeLevels[upgradeIndex]++;

        UpdateLevelDisplay(upgradeIndex);

        if (branchUpgrades.Length <= _tower.CurrentBranchUpgradeLevels[upgradeIndex])
        {
            _upgradeButtons[upgradeIndex].interactable = false;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
