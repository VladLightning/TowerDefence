using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/Slime")]
public class SlimeData : EnemyData
{
    [SerializeField] private EnemiesEnum _enemyTypeToSpawn;
    public EnemiesEnum EnemyTypeToSpawn => _enemyTypeToSpawn;
    
    [SerializeField] private int _clonesAmount;
    public int ClonesAmount => _clonesAmount;
}
