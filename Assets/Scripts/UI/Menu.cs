using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    private Pause _pause;

    private void Start()
    {
        _pause = GetComponent<Pause>();
    }

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
        _pause.PauseGame(isActive);
        _pause.enabled = !isActive;
    }
}
