using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Path _movementPath;

    [SerializeField] private int _enemiesAmount;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_spawnDelay);
        for(int i = 0; i < _enemiesAmount; i++)
        {
            GameObject enemy; 
            enemy = Instantiate(_enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
            enemy.GetComponent<EnemyMovement>().Path = _movementPath;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
