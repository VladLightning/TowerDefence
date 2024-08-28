using TMPro;
using UnityEngine;
public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyDisplay;
    [SerializeField] private LevelData _levelData;
    private int _moneyAmount;
    public int MoneyAmount => _moneyAmount;

    private void Start()
    {
        _moneyAmount = _levelData.StartMoney;
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        _moneyDisplay.text = _moneyAmount.ToString();
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        UpdateMoneyDisplay();
    }

    public void Purchase(int price)
    {
        _moneyAmount -= price;
        UpdateMoneyDisplay();
    }
}