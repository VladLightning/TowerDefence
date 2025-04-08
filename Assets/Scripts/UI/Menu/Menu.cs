
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameSettings;
    [SerializeField] private GameObject _glossary;

    public void Open()
    {
        _gameMenu.SetActive(!_gameMenu.activeSelf);
        _gameSettings.SetActive(false);
        _glossary.SetActive(false);
    }
}
