using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private Button[] _startWaveButtons;

    private void Start()
    {
        _startWaveButtons = GetComponentsInChildren<Button>();
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

        for (int i = 0; i < _startWaveButtons.Length; i++)
        {
            _startWaveButtons[i].interactable = true;
        }
    }

    public void StartWave()
    {
        StartCoroutine(SetButtonTimer());

        for (int i = 0; i < _startWaveButtons.Length; i++)
        {
            _startWaveButtons[i].interactable = false;
        }

        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].StartSpawnEnemy();
        }
    }
}
