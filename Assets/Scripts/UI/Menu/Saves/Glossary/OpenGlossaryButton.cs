
using UnityEngine;
public class OpenGlossaryButton : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameSettings;

    private void Start()
    {
        PlayerInputHandler.OnOpenGlossary += OpenGlossary;
    }

    private void OnDestroy()
    {
        PlayerInputHandler.OnOpenGlossary -= OpenGlossary;
    }

    public void OpenGlossary()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        _gameMenu.SetActive(false);
        _gameSettings.SetActive(false);
    }
}
