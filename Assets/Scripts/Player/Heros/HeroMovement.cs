using System.Collections;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private GameObject _hero;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _speed;

    private IEnumerator _move;

    private void OnMouseDown()
    {
        StartMovement();
    }

    private void StartMovement()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
        }
        LookAtMouse(_mainCamera.ScreenToWorldPoint(Input.mousePosition));

        _move = Move(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
        StartCoroutine(_move);
    }

    private void LookAtMouse(Vector2 targetPosition)
    {
        _hero.transform.localScale =
         (targetPosition.x < _hero.transform.position.x) 
         ? new Vector2(-Mathf.Abs(_hero.transform.localScale.x), _hero.transform.localScale.y)
         : new Vector2(Mathf.Abs(_hero.transform.localScale.x), _hero.transform.localScale.y);
    }

    private IEnumerator Move(Vector2 targetPosition)
    {
        while (Vector2.Distance(_hero.transform.position, targetPosition) > DISTANCE_THRESHOLD)
        {
            _hero.transform.position = Vector2.MoveTowards(_hero.transform.position, targetPosition, _speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

}
