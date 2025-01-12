using UnityEngine;
public abstract class Projectile : MonoBehaviour
{
    private readonly float _lifeTime = 5;

    protected DamageTypeEnum.DamageTypes _damageType;
    
    protected int _damage;

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

    public void Initialize(ProjectileLevels projectileLevel)
    {
        _damageType = DamageTypeEnum.DamageTypes.Physical;
        _damage = projectileLevel.Damage;
        ProjectileFly(projectileLevel.Force);
    }

    protected void ProjectileFly(float force)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
