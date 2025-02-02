using UnityEngine;
public abstract class Projectile : MonoBehaviour
{
    private readonly float _lifeTime = 5;

    protected DamageTypesEnum.DamageTypes _damageType;
    
    protected int _damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HitTarget(collision);
        }
    }

    protected virtual void HitTarget(Collider2D collision)
    {
        collision.GetComponent<Enemy>().TakeDamage(_damage);
        Destroy(gameObject);
    }
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    public void Initialize(ProjectileStats projectileStats)
    {
        _damageType = DamageTypesEnum.DamageTypes.Physical;
        _damage = projectileStats.Damage;
        ProjectileFly(projectileStats.Force);
    }

    protected void ProjectileFly(float force)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
