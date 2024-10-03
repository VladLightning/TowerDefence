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

    private bool _isSpawning;
    private bool _waveDelayIsActive;

    private void Start()
    {
        CountEnemies();
    }

    private IEnumerator WaveCycle()
    {
        _isSpawning = true;
        for (int i = 0; i < _waveData.Waves.Length; i++)
        {
            _startWaveButtons.SetButtonsActive(false);

            yield return StartCoroutine(Spawn(i));

            if(i == _waveData.Waves.Length - 1)
            {
                yield break;
            }

            _startWaveButtons.SetButtonsActive(true);

            _waveDelayIsActive = true;
            float nextWaveStartTime = Time.time + _waveData.Waves[i].WaveDelay;
            while (_waveDelayIsActive && Time.time < nextWaveStartTime)
            {
                yield return null;
            }
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

    private void DisableWaveDelay()
    {
        _waveDelayIsActive = false;
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
            amount += _waveData.Waves[i].WaveInstances.Length;
        }
        _victory.IncreaseEnemiesAmount(amount);
    }

    public void ActivateSpawner()
    {
        if(_isSpawning)
        {
            DisableWaveDelay();
            return;
        }
        StartWaveCycle();
    }
}