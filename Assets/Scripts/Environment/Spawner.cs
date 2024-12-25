using System;
using System.Collections;
using System.Linq;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public static event Action<int> OnEarlyWaveStart;
    public static event Action<int> OnIncreaseEnemyAmount;
    public static event Action<EnemiesEnum.EnemyTypes, Transform, Path> OnSpawnEnemy;
    
    [SerializeField] private Path _movementPath;

    [SerializeField] private StartWaveButtonsVisual _startWaveButtonsVisual;

    [SerializeField] private int _spawnerIndex;

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
        _startWaveButtonsVisual.SetButtonsActive(_waveData.Waves[_currentWaveIndex].WaveInstances.Length != 0, _spawnerIndex, false);
    }
    
    private IEnumerator WaveCycle()
    {
        _isSpawning = true;
        for (_currentWaveIndex = 0; _currentWaveIndex < _waveData.Waves.Length; _currentWaveIndex++)
        {
            _startWaveButtonsVisual.SetButtonsActive(false, _spawnerIndex);
            StartCoroutine(Spawn(_currentWaveIndex));
            yield return new WaitForSeconds(_buttonsActivationDelays[_currentWaveIndex]);

            if(_currentWaveIndex == _waveData.Waves.Length - 1)
            {
                yield break;
            }

            _startWaveButtonsVisual.SetButtonsActive(_waveData.Waves[_currentWaveIndex+1].WaveInstances.Length != 0, _spawnerIndex);

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
        foreach (var waveInstanceData in _waveData.Waves[index].WaveInstances)
        {
            OnSpawnEnemy?.Invoke(waveInstanceData.EnemyType, transform, _movementPath);
            yield return new WaitForSeconds(waveInstanceData.SpawnDelay);
        }
    }

    private int EarlyWaveStartReward(float timeSpent)
    {
        int maxReward = _waveData.Waves[_currentWaveIndex].EarlyWaveStartReward;
        float rewardCoefficient = (CurrentWaveDelay - timeSpent) / CurrentWaveDelay;

        return (int)(maxReward * rewardCoefficient);
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
        int amount = _waveData.Waves.Sum(wave => wave.WaveInstances.Length);
        OnIncreaseEnemyAmount?.Invoke(amount);
    }

    private IEnumerator ReceiveEarlyWaveStartReward(int index)
    {      
        yield return _startWaveButtonsVisual.StartCoroutine(_startWaveButtonsVisual.SpawnCoinsToAnimate(index));
        OnEarlyWaveStart?.Invoke(EarlyWaveStartReward(_delayCounter));
    }

    public void ActivateSpawner(int index)
    {
        if(_isSpawning && _waveData.Waves[_currentWaveIndex + 1].WaveInstances.Length != 0)
        {
            DisableWaveDelay();
            
            StartCoroutine(ReceiveEarlyWaveStartReward(index));
            
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