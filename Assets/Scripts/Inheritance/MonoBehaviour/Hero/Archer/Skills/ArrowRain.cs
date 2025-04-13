
using System.Collections;
using UnityEngine;

public class ArrowRain : MonoBehaviour, IDamageDealer
{
    private int _damage;
    public int Damage => _damage;
    
    private DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;
    
    private float _radius;

    private int _arrowsAmount;
    private float _animationInterval;
    
    private CircleCollider2D _collider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage, _damageType);
        }
    }

    public void Initiate(ArrowRainData arrowRainData)
    {
        _damageType = arrowRainData.DamageType;
        _animationInterval = arrowRainData.AnimationInterval;
        _arrowsAmount = arrowRainData.ArrowsAmount;
        
        _damage = arrowRainData.DamagePerArrow;
        _radius = arrowRainData.AreaRadius;

        transform.localScale *= _radius;
        _collider = GetComponent<CircleCollider2D>();
        
        StartCoroutine(RainArrows());
    }

    private IEnumerator RainArrows()
    {
        while (_arrowsAmount > 0)
        {
            _arrowsAmount--;
            
            yield return new WaitForSeconds(_animationInterval);
            _collider.enabled = false;
            _collider.enabled = true;
        }
        Destroy(gameObject);
    }
}
