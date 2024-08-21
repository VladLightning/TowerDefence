using UnityEngine;
public class MouseHeroMovement : MonoBehaviour
{
    private const float DISTANCE = 10;
    [SerializeField] private Camera _camera;
    private Hero _hero;
    public Hero Hero { set { _hero = value; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, DISTANCE, LayerMask.GetMask("Path"));
            if(hit.collider is not null)
            {
                _hero.StartMovement(targetPosition);
            }
        }
    }
}
