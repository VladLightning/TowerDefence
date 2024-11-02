using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFullscreen : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Dropdown _resolutionsDropdown;

    private void Start()
    {
        _toggle.isOn = PlayerPrefs.GetInt("Is fullscreen") == 1;
        OnToggle();
    }

    public void OnToggle()
    {
        Screen.fullScreen = _toggle.isOn;
        PlayerPrefs.SetInt("Is fullscreen", _toggle.isOn ? 1 : 0);
    }
}
