using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    private const float DISTANCE = 10;

    public static event Action<Transform> OnTowerSlotSelected;
    public static event Action<Tower> OnTowerSelected;
    public static event Action OnNothingSelected;
    public static event Action<Vector2> OnPathSelected;
    
    [SerializeField] private Camera _camera;

    [SerializeField] private LayerMask _layerMask;

    public void MouseInputHandler()
    {
        Vector2 targetPosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        var hit = Physics2D.Raycast(targetPosition, Vector2.zero, DISTANCE, _layerMask);

        if (hit.collider == null)
        {
            OnNothingSelected?.Invoke();
            return;
        }

        int layer = hit.collider.gameObject.layer;

        if (layer != LayerMask.NameToLayer("UI"))
        {
            OnNothingSelected?.Invoke();
        }

        if (layer == LayerMask.NameToLayer("Path"))
        {
            OnPathSelected?.Invoke(targetPosition);
        }
        else if (layer == LayerMask.NameToLayer("TowerSlot") && hit.transform.childCount == 0)
        {
            OnTowerSlotSelected?.Invoke(hit.transform);
        }
        else if (layer == LayerMask.NameToLayer("Tower"))
        {
            OnTowerSelected?.Invoke(hit.collider.GetComponentInParent<Tower>());
        }
    }
}
