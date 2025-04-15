
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class GlossaryEnemyDeathCounter : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<EnemiesEnum, int> _enemyDeathCounter;
    public SerializedDictionary<EnemiesEnum, int> EnemyDeathCounter => _enemyDeathCounter;

    [SerializeField] private EnemiesEnum[] _enemies;
    public EnemiesEnum[] Enemies => _enemies;
    
    private void Start()
    {
        Enemy.OnDeathCount += IncreaseDeathCount;
    }

    private void OnDestroy()
    {
        Enemy.OnDeathCount -= IncreaseDeathCount;
    }

    private void IncreaseDeathCount(EnemiesEnum enemyType)
    {
        _enemyDeathCounter[enemyType]++;
    }
}
