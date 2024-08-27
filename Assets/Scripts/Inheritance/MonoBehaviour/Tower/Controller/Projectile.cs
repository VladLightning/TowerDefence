using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
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
