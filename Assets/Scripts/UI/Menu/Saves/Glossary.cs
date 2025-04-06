
using UnityEngine;

public class Glossary : MonoBehaviour
{
    [SerializeField] private GameObject _glossary;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameSettings;

    public void OpenGlossary()
    {
        _glossary.SetActive(!_glossary.activeSelf);
        _gameMenu.SetActive(false);
        _gameSettings.SetActive(false);
    }
}
