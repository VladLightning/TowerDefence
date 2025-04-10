
using UnityEngine;
public class Glossary : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameSettings;

    private GlossaryDatabase _glossaryDatabase;
    public GlossaryDatabase GlossaryDatabase => _glossaryDatabase;

    private void Start()
    {
        _glossaryDatabase = GetComponent<GlossaryDatabase>();
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

    public void DisplayInfo(GlossaryEnum item)
    {
        _glossaryDatabase.DisplayInfo(item);
    }
}
