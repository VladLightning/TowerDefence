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
        $"{_tower.CurrentBranchUpgradeLevels[index]} / {_branchUpgradesData[index].UpgradePrices.Length}";
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
            var upgradePrices = _branchUpgradesData[i].UpgradePrices;
            if (upgradePrices.Length <= _tower.CurrentBranchUpgradeLevels[i])
            {
                continue;
            }        
            _upgradeButtons[i].interactable = upgradePrices[_tower.CurrentBranchUpgradeLevels[i]] <= _playerMoney.MoneyAmount;
        }
    }

    public void Upgrade(int upgradeIndex)
    {
        var upgradePrices = _branchUpgradesData[upgradeIndex].UpgradePrices;

        _playerMoney.Purchase(upgradePrices[_tower.CurrentBranchUpgradeLevels[upgradeIndex]]);

        _tower.CurrentBranchUpgradeLevels[upgradeIndex]++;

        UpdateLevelDisplay(upgradeIndex);

        if (upgradePrices.Length <= _tower.CurrentBranchUpgradeLevels[upgradeIndex])
        {
            _upgradeButtons[upgradeIndex].interactable = false;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
