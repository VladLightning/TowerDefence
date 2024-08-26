using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private float _force;
    public float Force { set { _force = value; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * _force);
        Destroy(gameObject, _lifeTime);
    }
}
