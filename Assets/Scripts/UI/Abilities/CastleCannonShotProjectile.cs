using UnityEngine;

public class CastleCannonShotProjectile : MonoBehaviour
{
    private LayerMask _mask;
    private float _explosionForce;
    private float _explosionRadius;
    private int _explosionDamage;

    public void InitProjectile(AbilityData abilityData)
    {
        var data = abilityData as CastleCannonAbilityData;
        
        _mask = data.Mask;
        _explosionForce = data.ExplosionForce;
        _explosionRadius = data.ExplosionRadius;
        _explosionDamage = data.ExplosionDamage;
    }
    
    public void Explode()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _mask);

        foreach (var enemyCollider in enemyColliders)
        {
            Vector2 direction = enemyCollider.transform.position - transform.position;
            direction.Normalize();
            
            enemyCollider.attachedRigidbody.AddForce(direction * _explosionForce);
            enemyCollider.GetComponent<Enemy>().TakeDamage(_explosionDamage);
        }
        
        Destroy(gameObject);
    }
}
