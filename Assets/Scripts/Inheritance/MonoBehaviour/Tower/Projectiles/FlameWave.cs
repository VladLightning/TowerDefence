using UnityEngine;

public class FlameWave : MonoBehaviour, IDamageDealer
{
    private int _damage;
    public int Damage => _damage;
    private DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage, _damageType);
        }
    }

    public void Initialize(float duration, float speed, int damage, DamageTypesEnum damageType)
    {
        _damage = damage;
        _damageType = damageType;
        
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, duration);
    }
}
