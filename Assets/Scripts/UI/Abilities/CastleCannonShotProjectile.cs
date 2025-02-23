using UnityEngine;

public class CastleCannonShotProjectile : MonoBehaviour, IProjectile
{
    private LayerMask _mask;
    private float _explosionForce;
    private float _explosionRadius;
    private int _explosionDamage;
    private DamageTypesEnum.DamageTypes _damageType;

    public void SetProjectileStats(LayerMask mask, float explosionForce, float explosionRadius, int explosionDamage, DamageTypesEnum.DamageTypes damageType)
    {
        _mask = mask;
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
        _explosionDamage = explosionDamage;
        _damageType = damageType;
    }
    
    public void Explode()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _mask);

        foreach (var enemyCollider in enemyColliders)
        {
            Vector2 direction = enemyCollider.transform.position - transform.position;
            direction.Normalize();
            
            enemyCollider.attachedRigidbody.AddForce(direction * _explosionForce);
            enemyCollider.GetComponent<Enemy>().TakeDamage(_explosionDamage, _damageType);
        }
        
        Destroy(gameObject);
    }
}
