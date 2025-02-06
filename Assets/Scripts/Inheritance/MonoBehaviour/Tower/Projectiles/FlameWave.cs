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

    public void Initialize(float duration, float speed, int damage)
    {
        _damage = damage;
        
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, duration);
    }
}
