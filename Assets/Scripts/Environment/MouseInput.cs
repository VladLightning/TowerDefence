using UnityEngine;
public class MouseInput : MonoBehaviour
{
    private const float DISTANCE = 10;
    [SerializeField] private Camera _camera;
    [SerializeField] private TowerManager _towerManager;
    private Hero _hero;
    public Hero Hero { set { _hero = value; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MouseInputHandler();
        }
    }

    private void MouseInputHandler()
    {
        Vector2 targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, DISTANCE, LayerMask.GetMask("Path", "TowerSlot"));
        if (hit.collider is null)
        {
            return;
        }
        if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Path"))
        {
            _hero.StartMovement(targetPosition);
        }
        else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("TowerSlot") && hit.transform.childCount == 1)
        {
            _towerManager.SetBuildPosition(hit.transform);
        }
    }
}
