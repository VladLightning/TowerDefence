using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private Button _startWaveButton;

    private void Start()
    {
        _startWaveButton = GetComponent<Button>();
    }

    private IEnumerator SetButtonTimer()
    {
        float longestSpawnCycle = _spawners[0].SpawnCycleTime;
        for (int i = 1; i < _spawners.Length; i++)
        {
            if (_spawners[i].SpawnCycleTime > longestSpawnCycle)
            {
                longestSpawnCycle = _spawners[i].SpawnCycleTime;
            }
        }

        yield return new WaitForSeconds(longestSpawnCycle);

        _startWaveButton.interactable = true;
    }

    public void StartWave()
    {
        StartCoroutine(SetButtonTimer());

        _startWaveButton.interactable = false;

        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].StartSpawnEnemy();
        }
    }
}
