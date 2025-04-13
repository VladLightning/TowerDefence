using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "WavesData")]
public class WaveData : ScriptableObject
{
    [SerializeField] private Waves[] _waves;
    public Waves[] Waves => _waves;
}
[System.Serializable]
public class Waves
{
    [SerializeField] private int _earlyWaveStartReward;
    public int EarlyWaveStartReward => _earlyWaveStartReward;

    [SerializeField] private WaveInstanceData[] _waveInstances;
    public WaveInstanceData[] WaveInstances => _waveInstances;
    [SerializeField] private int _waveDelay;
    public int WaveDelay => _waveDelay;

    public int GetTotalDelay()
    {
        return _waveInstances.Sum(t => t.SpawnDelay);
    }
}

[System.Serializable]
public class WaveInstanceData
{
    [SerializeField] private EnemiesEnum _enemyType;
    public EnemiesEnum EnemyType => _enemyType;

    [SerializeField] private int _spawnDelay;
    public int SpawnDelay => _spawnDelay;
}
