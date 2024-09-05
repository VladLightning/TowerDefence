using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    private Tower _tower;

    public void Enable(Tower tower)
    {        
        _tower = tower;
        UpgradeButtonIsAvailable();

        Disable();
        transform.position = _tower.transform.position;
        gameObject.SetActive(true); 
    }

    public void Disable()
    {
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
