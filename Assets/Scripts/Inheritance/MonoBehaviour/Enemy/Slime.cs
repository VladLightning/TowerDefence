
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slime : Enemy
{
    public static event Action<int> OnSplit;
    public static event Func<EnemiesEnum.EnemyTypes, Vector2, Enemy> OnSpawnEnemy;

    private readonly float _minimumSpawnOffset = -1;
    private readonly float _maximumSpawnOffset = 1;

    private EnemiesEnum.EnemyTypes _enemyType;
    private int _clonesAmount;

    protected override void Initiate()
    {
        base.Initiate();
        
        var slimeData = _entityData as SlimeData;

        _enemyType = slimeData.EnemyType;
        _clonesAmount = slimeData.ClonesAmount;
    }
    
    protected override void Death()
    {
        Split();
        base.Death();
    }

    private void Split()
    {
        OnSplit?.Invoke(_clonesAmount);
        for (int i = 0; i < _clonesAmount; i++)
        {
            var clone = OnSpawnEnemy?.Invoke(_enemyType, transform.position + 
                                                         new Vector3(Random.Range(_minimumSpawnOffset, _maximumSpawnOffset), Random.Range(_minimumSpawnOffset, _maximumSpawnOffset)));
            clone.Initiate(Path);
            clone.GetComponent<Enemy>().CurrentPointIndex = _currentPointIndex;
        }
    }
}
