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

    private void SpawnEnemy(EnemiesEnum.EnemyTypes enemyType, Transform spawnPoint, Path movementPath)
    {
        if (_enemies.TryGetValue(enemyType, out var enemy))
        {
            var enemyInstance = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            enemyInstance.GetComponent<Enemy>().Initiate(movementPath);
        }
        else
        {
            throw new NullReferenceException("No enemy found in dictionary");
        }
    }
}
