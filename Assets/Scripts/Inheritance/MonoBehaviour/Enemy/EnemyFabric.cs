using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializedDictionary("Enemies","Prefabs")]
    [SerializeField] private SerializedDictionary<EnemiesEnum.EnemyTypes, GameObject> _enemies;

    private void OnEnable()
    {
        Spawner.OnSpawnEnemy += SpawnEnemy;
    }

    private void OnDisable()
    {
        Spawner.OnSpawnEnemy -= SpawnEnemy;
    }

    private Enemy SpawnEnemy(EnemiesEnum.EnemyTypes enemyType, Transform spawnPoint)
    {
        if (_enemies.TryGetValue(enemyType, out var enemy))
        {
            return Instantiate(enemy, spawnPoint.position, spawnPoint.rotation).GetComponent<Enemy>();
        }
        throw new NullReferenceException("No enemy found in dictionary");
    }
}
