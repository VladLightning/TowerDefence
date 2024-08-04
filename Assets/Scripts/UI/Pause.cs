using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame(!_isPaused);
        }
    }

    public void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
        _pausePanel.SetActive(isPaused);
        _isPaused = isPaused;
    }
}
