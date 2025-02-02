using UnityEngine;

public class FlameWave : MonoBehaviour
{
    private int _damage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }

    public void Initialize(float duration, float speed, int damage, Transform target)
    {
        _damage = damage;
        
        var direction = target.position - transform.position;
        
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(gameObject, duration);
    }
}
