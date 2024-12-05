using UnityEngine;

public class FreezeProjectile : MonoBehaviour, IProjectile
{
    private LayerMask _mask;
    private float _freezeRadius;
    private float _movementSpeedReductionCoefficient;
    private float _freezeDuration;
    
    public void SetProjectileStats(LayerMask mask, float freezeRadius, float movementSpeedReductionCoefficient, float freezeDuration)
    {
        _mask = mask;
        _freezeRadius = freezeRadius;
        _movementSpeedReductionCoefficient = movementSpeedReductionCoefficient;
        _freezeDuration = freezeDuration;
    }

    public void Explode()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _freezeRadius, _mask);

        foreach(var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<Enemy>().StartSlowDownMovement(_movementSpeedReductionCoefficient, _freezeDuration);
        }
        
        Destroy(gameObject);
    }
}
