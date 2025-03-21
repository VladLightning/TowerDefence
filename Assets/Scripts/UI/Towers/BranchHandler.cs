using UnityEngine;
using UnityEngine.UI;

public class BranchHandler : MonoBehaviour
{
    [SerializeField] private TowerUpgradePanel _towerUpgradePanel;

    [SerializeField] private Button[] _branchChoiceButtons;
    [SerializeField] private PlayerMoney _playerMoney;

    private Tower _tower;

    public void SetBranchChoice(Tower tower)
    {
        gameObject.SetActive(true);      

        _tower = tower;

        ChoiceButtonIsAvailable();

        for (int i = 0; i < _tower.TowerBranchData.Length; i++)
        {
            _branchChoiceButtons[i].image.sprite = _tower.TowerBranchData[i].TowerSprite;
        }
    }

    public void SetBranch(int index)
    {
        _tower.SetBranch(index);
        _towerUpgradePanel.ResetToDefaultState();
        Disable();
    }

    public void ChoiceButtonIsAvailable()
    {
        for(int i = 0; i < _branchChoiceButtons.Length; i++)
        {
            _branchChoiceButtons[i].interactable = _tower.TowerBranchData[i].TowerLevels[0].Price <= _playerMoney.MoneyAmount;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);       
    }
}
