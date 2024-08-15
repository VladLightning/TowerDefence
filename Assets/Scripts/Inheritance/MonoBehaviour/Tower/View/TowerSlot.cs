using UnityEngine;
public class TowerSlot : MonoBehaviour
{
    [SerializeField] private TowerManager _towerManager;

    private void OnMouseDown()
    {
        _towerManager.SetBuildPosition(transform);
    }
}