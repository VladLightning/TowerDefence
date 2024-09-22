using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private Path _movementPath;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private EnemyData[] _enemyData;

    [SerializeField] private int _enemiesAmount;
    [SerializeField] private float _spawnDelay;

    private float _spawnCycleTime;
    public float SpawnCycleTime => _spawnCycleTime;

    private bool _isSpawning;

    private void Start()
    {
        for (int i = 0; i < _enemiesAmount+1; i++)
        {
            _spawnCycleTime += _spawnDelay;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        _isSpawning = true;
        yield return new WaitForSeconds(_spawnDelay);
        for(int i = 0; i < _enemiesAmount; i++)
        {            
            GameObject enemy = Instantiate(_enemyToSpawn, transform.position, transform.rotation);
            enemy.GetComponent<Enemy>().Initiate(_enemyData[0], _movementPath, _playerHealth, _playerMoney);
            yield return new WaitForSeconds(_spawnDelay);
        }
        _isSpawning = false;
    }

    public void StartSpawnEnemy()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnEnemy());
        }
    }
}