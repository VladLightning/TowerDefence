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
    [SerializeField] private WaveInstanceData[] _waveInstances;
    public WaveInstanceData[] WaveInstances => _waveInstances;
    [SerializeField] private int _waveDelay;
    public int WaveDelay => _waveDelay;
}

[System.Serializable]
public class WaveInstanceData
{
    [SerializeField] private GameObject _enemy;
    public GameObject Enemy => _enemy;

    [SerializeField] private int _spawnDelay;
    public int SpawnDelay => _spawnDelay;
}