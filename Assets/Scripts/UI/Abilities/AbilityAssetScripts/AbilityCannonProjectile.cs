using System;
using UnityEngine;

public class AbilityCannonProjectile : MonoBehaviour
{

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _explosionDamage;
    
    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, LayerMask.GetMask("Enemy"));;
        
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector2 direction = colliders[i].transform.position - transform.position;
            direction.Normalize();
            
            colliders[i].GetComponent<Rigidbody2D>().AddForce(direction * _explosionForce);
            colliders[i].GetComponent<Enemy>().TakeDamage(_explosionDamage);
        }
    }
    
    private void OnDestroy()
    {
        Explode();
    }
}
