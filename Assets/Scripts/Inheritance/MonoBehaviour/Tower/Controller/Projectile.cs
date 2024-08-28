using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }
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
