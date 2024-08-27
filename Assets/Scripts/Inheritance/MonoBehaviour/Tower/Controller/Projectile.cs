using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private int _damage;
    public int Damage { set {  _damage = value; } }

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

    public void ProjectileFly(float force)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
