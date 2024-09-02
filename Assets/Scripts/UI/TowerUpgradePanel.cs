using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
    private Tower _tower;

    public void Enable(Tower tower)
    {
        if(_tower != tower)
        {
            _tower = tower;
            Disable();
        }
        if (gameObject.activeSelf)
        {
            return;
        }
        transform.position = _tower.transform.position;
        gameObject.SetActive(true); 
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        gameObject.SetActive(false);
    }
}
