using UnityEngine;
public abstract class Projectile : MonoBehaviour, IDamageDealer
{
    private readonly float _lifeTime = 5;

    protected DamageTypesEnum.DamageTypes _damageType;
    public DamageTypesEnum.DamageTypes DamageType => _damageType;
    private int _damage;
    public int Damage => _damage;

    private float _damageCoefficient;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HitTarget(collision);
        }
    }

    protected virtual void HitTarget(Collider2D collision)
    {
        collision.GetComponent<Enemy>().TakeDamage(_damage, _damageType);
        Destroy(gameObject);
    }
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    public virtual void Initialize(ProjectileStats projectileStats, float damageCoefficient = 1, DamageTypesEnum.DamageTypes damageType = DamageTypesEnum.DamageTypes.Physical)
    {
        _damageType = damageType;
        _damageCoefficient = damageCoefficient;
        _damage = (int)(projectileStats.Damage * _damageCoefficient);
        ProjectileFly(projectileStats.Force);
    }

    private void ProjectileFly(float force)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
