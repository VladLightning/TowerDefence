using System.Collections;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _speed;

    private IEnumerator _move;

    public void StartMovement()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
        }

        Vector2 targetPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        LookAtMouse(targetPosition);
        _move = Move(targetPosition);
        StartCoroutine(_move);
    }

    private void LookAtMouse(Vector2 targetPosition)
    {
        transform.localScale =
         (targetPosition.x < transform.position.x) 
         ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y)
         : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private IEnumerator Move(Vector2 targetPosition)
    {
        while (Vector2.Distance(transform.position, targetPosition) > DISTANCE_THRESHOLD)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

}
