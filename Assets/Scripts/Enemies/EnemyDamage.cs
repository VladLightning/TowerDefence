using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    [SerializeField] private int _damage;

    private PlayerHealth _playerHealth;

    public PlayerHealth PlayerHealth { set { _playerHealth = value; } }

    public void DealDamage()
    {
        _playerHealth.TakeDamage(_damage);
    }
}
