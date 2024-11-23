using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Dropdown _resolutionsDropdown;

    private void Start()
    {
        _toggle.isOn = PlayerPrefs.GetInt(Saves.IS_FULLSCREEN) == 1;
        OnToggle();
    }

    public void OnToggle()
    {
        Screen.fullScreen = _toggle.isOn;
        PlayerPrefs.SetInt(Saves.IS_FULLSCREEN, _toggle.isOn ? 1 : 0);
    }
}
