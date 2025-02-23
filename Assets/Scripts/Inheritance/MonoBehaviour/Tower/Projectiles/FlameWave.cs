using UnityEngine;

public class FlameWave : MonoBehaviour
{
    private int _damage;
    private DamageTypesEnum.DamageTypes _damageType;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage, _damageType);
        }
    }

    public void Initialize(float duration, float speed, int damage, DamageTypesEnum.DamageTypes damageType)
    {
        _damage = damage;
        _damageType = damageType;
        
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, duration);
    }
}
