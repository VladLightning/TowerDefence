using System;
using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Path _movementPath;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private Victory _victory;

    [SerializeField] private StartWaveButtonsVisual _startWaveButtons;

    private WaveData _waveData;

    private float[] _buttonsActivationDelays;
    public float CurrentWaveDelay => _waveData.Waves[_currentWaveIndex].WaveDelay;

    private float _delayCounter;

    private int _currentWaveIndex;

    private bool _isSpawning;
    private bool _waveDelayIsActive;

    private void Start()
    {
        CountEnemies();
    }

    private IEnumerator WaveCycle()
    {
        _isSpawning = true;
        for (_currentWaveIndex = 0; _currentWaveIndex < _waveData.Waves.Length; _currentWaveIndex++)
        {
            _startWaveButtons.SetButtonsActive(false);
            StartCoroutine(Spawn(_currentWaveIndex));
            yield return new WaitForSeconds(_buttonsActivationDelays[_currentWaveIndex]);

            if(_currentWaveIndex == _waveData.Waves.Length - 1)
            {
                yield break;
            }

            _startWaveButtons.SetButtonsActive(true);

            _waveDelayIsActive = true;
            _delayCounter = 0;
            while (_waveDelayIsActive && _delayCounter < CurrentWaveDelay)
            {
                _delayCounter += Time.deltaTime;
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

    private int DelaySkipReward(float timeSpent)
    {
        int maxReward = _waveData.Waves[_currentWaveIndex].MaxDelaySkipReward;
        float rewardCoefficient = (CurrentWaveDelay - timeSpent) / CurrentWaveDelay;

        return (int)(maxReward * rewardCoefficient);
    }

    private void DisableWaveDelay()
    {
        _waveDelayIsActive = false;
        _playerMoney.AddMoney(DelaySkipReward(_delayCounter));
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

    public void SetWaveData(WaveData waveData, float[] buttonsActivationDelay)
    {
        _waveData = waveData;
        _buttonsActivationDelays = buttonsActivationDelay;
    }
}