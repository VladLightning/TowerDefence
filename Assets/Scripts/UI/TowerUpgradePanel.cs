using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
    private Tower _tower;

    public void Enable(Vector2 targetPosition, Tower tower)
    {
        if (gameObject.activeSelf)
        {
            return;
        }
        gameObject.SetActive(true); 
        _tower = tower;
        transform.position = targetPosition;
    }

    public void ExecuteTowerSell()
    {
        _tower.Sell();
        gameObject.SetActive(false);
    }
}
