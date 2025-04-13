using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializedDictionary("Enemies","Prefabs")]
    [SerializeField] private SerializedDictionary<EnemiesEnum, GameObject> _enemies;

    private void OnEnable()
    {
        Spawner.OnSpawnEnemy += SpawnEnemy;
        Slime.OnSpawnEnemy += SpawnEnemy;
    }

    private void OnDisable()
    {
        Spawner.OnSpawnEnemy -= SpawnEnemy;
        Slime.OnSpawnEnemy -= SpawnEnemy;
    }

    private Enemy SpawnEnemy(EnemiesEnum enemyType, Vector2 spawnPoint)
    {
        if (_enemies.TryGetValue(enemyType, out var enemy))
        {
            return Instantiate(enemy, spawnPoint, Quaternion.identity).GetComponent<Enemy>();
        }
        throw new NullReferenceException("No enemy found in dictionary");
    }
}
