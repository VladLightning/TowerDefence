using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private Path _movementPath;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyData[] _enemyData;

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
            GameObject enemy = Instantiate(_enemyToSpawn, transform.position, transform.rotation);
            enemy.GetComponent<Enemy>().Initiate(_enemyData[0], _movementPath, _playerHealth);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}