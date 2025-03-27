using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/Slime")]
public class SlimeData : EnemyData
{
    [SerializeField] private EnemiesEnum.EnemyTypes _enemyType;
    public EnemiesEnum.EnemyTypes EnemyType => _enemyType;
    
    [SerializeField] private int _clonesAmount;
    public int ClonesAmount => _clonesAmount;
}
