using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown languageDropdown;

    private void Start()
    {
        languageDropdown.value = PlayerPrefs.GetInt("Language");
    }

    public void ChangeGameLanguage(int locale)
    {
        StartCoroutine(SetLanguage(locale));
    }

    private IEnumerator SetLanguage(int locale)
    {
        languageDropdown.interactable = false;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[locale];
        PlayerPrefs.SetInt("Language", locale);
        languageDropdown.interactable = true;
    }
}
