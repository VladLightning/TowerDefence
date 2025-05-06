using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/ExplosivePumpkin")]
public class ExplosivePumpkinData : ExplosiveEnemyData
{
    [SerializeField] private float _takeDamageChance;
    public float TakeDamageChance => _takeDamageChance;
    
    [SerializeField] private int _guaranteedDamageHit;
    public int GuaranteedDamageHit => _guaranteedDamageHit;
}
