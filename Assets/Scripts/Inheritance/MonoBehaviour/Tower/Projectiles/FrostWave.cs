
using UnityEngine;

public class FrostWave : MonoBehaviour
{
    private float _speedReductionCoefficient;
    private float _speedReductionDuration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().StartSlowDownMovement(_speedReductionCoefficient, _speedReductionDuration);
        }
    }

    public void Initialize(float speedReduction, float speedReductionDuration, float radius, float duration)
    {
        transform.localScale *= radius;
        
        _speedReductionCoefficient = speedReduction;
        _speedReductionDuration = speedReductionDuration;
        
        Destroy(gameObject, duration);
    }
}
