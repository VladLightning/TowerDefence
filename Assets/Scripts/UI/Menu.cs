using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu(!_gameMenu.activeSelf);
        }
    }

    public void OpenMenu(bool isActive)
    {
        _gameMenu.SetActive(isActive);
        PauseGame(isActive);
    }

    public void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
