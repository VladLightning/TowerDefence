using UnityEngine;
using UnityEngine.UI;

public class BranchHandler : MonoBehaviour
{
    [SerializeField] private Button[] _branchChoiceButtons;
    [SerializeField] private PlayerMoney _playerMoney;

    private Tower _tower;

    public void SetBranchChoice(Tower tower)
    {
        if(tower.CurrentTowerBranchData != null)
        {
            Disable();
            return;
        }

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
        _tower.SetBranch(_tower.TowerBranchData[index]);
        Disable();
    }

    public void ChoiceButtonIsAvailable()
    {
        for(int i = 0; i < _branchChoiceButtons.Length; i++)
        {
            _branchChoiceButtons[i].interactable = _tower.TowerBranchData[i].Price <= _playerMoney.MoneyAmount;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
