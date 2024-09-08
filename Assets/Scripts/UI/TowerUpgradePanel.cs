using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _towerBranchChoicePanel;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceDisplay;

    private Button[] _branchChoiceButtons;

    private Tower _tower;

    private void SetBranchChoice(TowerBranchData[] towerBranches)
    {
        if (!_tower.IsMaxLevel())
        {
            return;
        }

        _towerBranchChoicePanel.SetActive(true);
        _branchChoiceButtons = _towerBranchChoicePanel.GetComponentsInChildren<Button>();

        for(int i = 0;  i < towerBranches.Length; i++)
        {
            _branchChoiceButtons[i].image.sprite = towerBranches[i].TowerSprite;
        }
    }

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();
        _priceDisplay.text = _tower.IsMaxLevel() ? "Max level" : _tower.TowerLevels[_tower.TowerLevelIndex].Price.ToString();

        Disable();

        SetBranchChoice(_tower.TowerBranchData);

        transform.position = _tower.transform.position;
        gameObject.SetActive(true); 
    }

    public void Disable()
    {
        _towerBranchChoicePanel.SetActive(false);
        gameObject.SetActive(false);
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
        if(_tower == null)
        {
            return;
        }
        _upgradeButton.interactable = _tower.IsUpgradeAvailable();
    }
}
