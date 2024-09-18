using TMPro;
using UnityEngine;
public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyDisplay;
    [SerializeField] private LevelData _levelData;

    [SerializeField] private TowerUpgradePanel _towerUpgradePanel;
    [SerializeField] private BranchHandler _branchHandler;
    [SerializeField] private BranchUpgradesHandler _branchUpgradesHandler;

    private int _moneyAmount;
    public int MoneyAmount => _moneyAmount;

    private void Start()
    {
        _moneyAmount = _levelData.StartMoney;
        UpdateMoneyDisplay();
    }

    public void CheckUpgradeIsAvailable()
    {
        if(_towerUpgradePanel.gameObject.activeSelf)
        {
            _towerUpgradePanel.UpgradeButtonIsAvailable();
        }
        if(_branchHandler.gameObject.activeSelf)
        {
            _branchHandler.ChoiceButtonIsAvailable();
        }
        if (_branchUpgradesHandler.gameObject.activeSelf)
        {
            _branchUpgradesHandler.UpgradeButtonIsAvailable();
        }
    }

    private void UpdateMoneyDisplay()
    {
        _moneyDisplay.text = _moneyAmount.ToString();
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        UpdateMoneyDisplay();
        CheckUpgradeIsAvailable();
    }

    public void Purchase(int price)
    {
        _moneyAmount -= price;
        UpdateMoneyDisplay();
        CheckUpgradeIsAvailable();
    }
}