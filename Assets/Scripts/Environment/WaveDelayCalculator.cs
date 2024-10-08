using UnityEngine;

public class WaveDelayCalculator : MonoBehaviour
{
    [SerializeField] private WaveData[] _waveDatas;

    private Spawner[] _spawners;

    private float[] _longestDelays;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();

        _longestDelays = new float[_waveDatas[0].Waves.Length];
        for (int i = 0; i < _waveDatas.Length; i++)
        {
            for (int j = 0; j < _waveDatas[i].Waves.Length; j++)
            {
                float currentWaveTotalDelay = _waveDatas[i].Waves[j].GetTotalDelay();
                if (_longestDelays[j] < currentWaveTotalDelay)
                {
                    _longestDelays[j] = currentWaveTotalDelay;
                }                
            }
        }

        SetSpawnersWaveData();
    }

    private void SetSpawnersWaveData()
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].SetWaveData(_waveDatas[i], _longestDelays);
        }
    }
}
