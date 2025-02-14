using UnityEngine;
using UnityEngine.InputSystem;

public class RadiusDrawer : MonoBehaviour
{
    private readonly int _pointsAmount = 50;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private LineRenderer _lineRenderer;

    private Transform _target;

    private void OnEnable()
    {
        AoEAbility.OnAoEAbilitySelect += EnableRadiusDisplay;
        AoEAbility.OnAoEAbilityDeselect += DisableRadiusDisplay;
        
        TowerUpgradePanel.OnTowerSelected += EnableRadiusDisplay;
        TowerUpgradePanel.OnTowerDeselected += DisableRadiusDisplay;
    }

    private void OnDisable()
    {
        AoEAbility.OnAoEAbilitySelect -= EnableRadiusDisplay;
        AoEAbility.OnAoEAbilityDeselect -= DisableRadiusDisplay;
        
        TowerUpgradePanel.OnTowerSelected -= EnableRadiusDisplay;
        TowerUpgradePanel.OnTowerDeselected -= DisableRadiusDisplay;
    }

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _pointsAmount;
        DisableRadiusDisplay();
    }

    private void Update()
    {
        if (_target == null)
        {
            var position = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            gameObject.transform.position = new Vector3(position.x, position.y, 0);
        }
    }

    private void EnableRadiusDisplay(float radius, Transform target)
    {
        _target = target;

        transform.position = _target?.position ?? Vector3.zero;
        
        float angle = 0f;

        for (int i = 0; i < _pointsAmount; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            var position = new Vector3(x, y, 0);
            
            _lineRenderer.SetPosition(i, position);
            angle += 360f / _pointsAmount;
        }
        _lineRenderer.enabled = true;
    }

    private void DisableRadiusDisplay()
    {
        _lineRenderer.enabled = false;
    }
}
