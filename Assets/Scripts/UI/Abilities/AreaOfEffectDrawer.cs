using UnityEngine;
using UnityEngine.InputSystem;

public class AreaOfEffectDrawer : MonoBehaviour
{
    private readonly int _pointsAmount = 50;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private LineRenderer _lineRenderer;

    private void OnEnable()
    {
        AoEAbility.OnAoEAbilitySelect += EnableAoEDisplay;
        AoEAbility.OnAoEAbilityDeselect += DisableAoEDisplay;
    }

    private void OnDisable()
    {
        AoEAbility.OnAoEAbilitySelect -= EnableAoEDisplay;
        AoEAbility.OnAoEAbilityDeselect -= DisableAoEDisplay;
    }

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _pointsAmount;
        DisableAoEDisplay();
    }

    private void Update()
    {
        var position = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gameObject.transform.position = new Vector3(position.x, position.y, 0);
    }

    private void EnableAoEDisplay(float radius)
    {
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

    private void DisableAoEDisplay()
    {
        _lineRenderer.enabled = false;
    }
}
