using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    private const float DISTANCE = 10;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private TowerManager _towerManager;
    [SerializeField] private TowerUpgradePanel _towerUpgradePanel;

    private Hero _hero;
    public Hero Hero { set { _hero = value; } }

    public void MouseInputHandler()
    {
        Vector2 targetPosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, DISTANCE, LayerMask.GetMask("Path", "TowerSlot", "Tower", "UI"));

        if (hit.collider == null)
        {
            _towerUpgradePanel.ResetToDefaultState();
            return;
        }

        int layer = hit.collider.gameObject.layer;

        if (layer != LayerMask.NameToLayer("UI"))
        {
            _towerUpgradePanel.ResetToDefaultState();
        }

        if (layer == LayerMask.NameToLayer("Path"))
        {
            _hero.StartMovement(targetPosition);
        }
        else if (layer == LayerMask.NameToLayer("TowerSlot") && hit.transform.childCount == 0)
        {
            _towerManager.SetBuildPosition(hit.transform);
        }
        else if (layer == LayerMask.NameToLayer("Tower"))
        {
            _towerUpgradePanel.Enable(hit.collider.GetComponentInParent<Tower>());
        }
    }
}
