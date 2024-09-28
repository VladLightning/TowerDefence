using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Path _movementPath;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private WaveData _waveData;

    [SerializeField] private StartWaveButtons _startWaveButtons;

    private IEnumerator _waveDelay;

    private void Start()
    {
        _waveDelay = WaveDelay(0);
    }

    private IEnumerator WaveCycle()
    {
        for (int i = 0; i < _waveData.Waves.Length; i++)
        {
            _startWaveButtons.SetButtonsActive(false);

            yield return StartCoroutine(Spawn(i));

            _startWaveButtons.SetButtonsActive(true);

            _waveDelay = WaveDelay(i);
            yield return StartCoroutine(_waveDelay);
        }
    }

    private IEnumerator Spawn(int index)
    {
        for (int j = 0; j < _waveData.Waves[index].Enemies.Length; j++)
        {
            var enemyToSpawn = _waveData.Waves[index].Enemies[j];

            GameObject enemy = Instantiate(enemyToSpawn.Enemy, transform.position, transform.rotation);
            enemy.GetComponent<Enemy>().Initiate(_movementPath, _playerHealth, _playerMoney);
            yield return new WaitForSeconds(enemyToSpawn.SpawnDelay);
        }
    }

    private IEnumerator WaveDelay(int index)
    {
        yield return new WaitForSeconds(_waveData.Waves[index].WaveDelay);
    }

    public void DisableWaveDelay()
    {
        StopCoroutine(_waveDelay);
    }

    public void StartWaveCycle()
    {
        StartCoroutine(WaveCycle());
    }
}