using UnityEngine;

public class FreezeProjectile : MonoBehaviour
{
    private LayerMask _mask;
    private float _freezeRadius;
    private float _movementSpeedReductionCoefficient;
    private float _freezeDuration;
    
    public void InitProjectile(LayerMask mask, float freezeRadius, float movementSpeedReductionCoefficient, float freezeDuration)
    {
        _mask = mask;
        _freezeRadius = freezeRadius;
        _movementSpeedReductionCoefficient = movementSpeedReductionCoefficient;
        _freezeDuration = freezeDuration;
    }

    public void Freeze()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _freezeRadius, _mask);

        foreach(var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<Enemy>().StartSlowDownMovement(_movementSpeedReductionCoefficient, _freezeDuration);
        }
        
        Destroy(gameObject);
    }
}
