using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButtons : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    private Button[] _startWaveButtons;

    private void Start()
    {
        _startWaveButtons = GetComponentsInChildren<Button>();
    }

    private void ActivateSpawners()
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].DisableWaveDelay();
            _spawners[i].StartSpawnEnemy();         
        }
    }

    public void OnClick()
    {
        SetButtonsActive(true);
        ActivateSpawners();
    }

    public void SetButtonsActive(bool value)
    {
        for (int i = 0; i < _startWaveButtons.Length; i++)
        {
            _startWaveButtons[i].gameObject.SetActive(value);
        }
    }
}
