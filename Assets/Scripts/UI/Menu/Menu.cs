using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    public void Open()
    {
        OpenMenu(!_gameMenu.activeSelf);
    }

    private void OpenMenu(bool isActive)
    {
        _gameMenu.SetActive(isActive);
        PauseGame(isActive);
    }

    private void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
