using UnityEngine;
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private int _damage;

    protected abstract void TriggerEffect(Collider2D collision);
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HitTarget(collision);
        }
    }

    private void HitTarget(Collider2D collision)
    {
        collision.GetComponent<Enemy>().TakeDamage(_damage);
        TriggerEffect(collision);
        Destroy(gameObject);
    }
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    public void Initialize(float force, int damage)
    {
        _damage = damage;
        ProjectileFly(force);
    }

    private void ProjectileFly(float force)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}