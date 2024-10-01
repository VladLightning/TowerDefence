using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Path _movementPath;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private Victory _victory;

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
        for (int i = 0; i < _waveData.Waves[index].WaveInstances.Length; i++)
        {
            var waveInstanceData = _waveData.Waves[index].WaveInstances[i];

            GameObject enemy = Instantiate(waveInstanceData.Enemy, transform.position, transform.rotation);
            enemy.GetComponent<Enemy>().Initiate(_movementPath, _playerHealth, _playerMoney, _victory);
            yield return new WaitForSeconds(waveInstanceData.SpawnDelay);
        }
    }

    private IEnumerator WaveDelay(int index)
    {
        yield return new WaitForSeconds(_waveData.Waves[index].WaveDelay);
    }

    private void DisableWaveDelay()
    {
        StopCoroutine(_waveDelay);
    }

    private void StartWaveCycle()
    {
        StartCoroutine(WaveCycle());
    }

    private void CountEnemies()
    {
        int amount = 0;
        for (int i = 0; i < _waveData.Waves.Length; i++)
        {
            for (int j = 0; j < _waveData.Waves[i].WaveInstances.Length; j++)
            {
                amount++;
            }
        }
        _victory.IncreaseEnemiesAmount(amount);
    }

    public void ActivateSpawner()
    {
        DisableWaveDelay();
        StartWaveCycle();
        CountEnemies();
    }
}