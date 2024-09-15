using UnityEngine;
using UnityEngine.UI;

public class BranchUpgradesHandler : MonoBehaviour
{
    [SerializeField] private Button[] _upgradeButtons;
    [SerializeField] private PlayerMoney _playerMoney;

    private Tower _tower;
    private BranchUpgradeData[] _branchUpgradesData;

    public void Enable(Tower tower)
    {
        gameObject.SetActive(true);

        _tower = tower;
        _branchUpgradesData = _tower.CurrentTowerBranchData.BranchUpgradesData;

        UpgradeButtonIsAvailable();

        for(int i = 0; i < _branchUpgradesData.Length; i++)
        {
            _upgradeButtons[i].image.sprite = _branchUpgradesData[i].Sprite;
        }
    }

    public void UpgradeButtonIsAvailable()
    {
        for (int i = 0; i < _upgradeButtons.Length; i++)
        {
            _upgradeButtons[i].interactable = _branchUpgradesData[i].Price <= _playerMoney.MoneyAmount;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
