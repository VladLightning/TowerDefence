
using System.Collections;
using UnityEngine;

public class ArcherDetectShootingTarget : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider2D;
    public CircleCollider2D Collider2D => _collider2D;
    
    private Transform _targetToShoot;
    public Transform TargetToShoot => _targetToShoot;
    
    private Archer _archer;
    
    private IEnumerator _shoot;

    private void Start()
    {
        _archer = GetComponentInParent<Archer>();
        _shoot = _archer.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !_archer.ShootingIsActive)
        {
            FindTarget();
            StartCoroutine(_shoot);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform == _targetToShoot)
        {
            FindTarget();
            _shoot = _archer.Shoot();
        }
    }
        
    public void FindTarget()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _collider2D.radius, LayerMask.GetMask("Enemy"));

        if(enemyColliders.Length == 0)
        {
            _targetToShoot = null;
            return;
        }

        float shortestDistance = Vector2.Distance(enemyColliders[0].transform.position, transform.position);
        int shortestDistanceIndex = 0;

        for (int i = 1; i < enemyColliders.Length; i++)
        {          
            float newDistance = Vector2.Distance(enemyColliders[i].transform.position, transform.position);
            if (shortestDistance > newDistance)
            {
                shortestDistance = newDistance;
                shortestDistanceIndex = i;
            }
        }
        _targetToShoot = enemyColliders[shortestDistanceIndex].transform;
    }

}
