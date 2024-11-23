using TMPro;
using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    [SerializeField] private Resolution[] _resolutions;

    [SerializeField] private TMP_Dropdown _resolutionsDropdown;

    private void Awake()
    {
        SortMaxRefreshRate();
        _resolutionsDropdown.value = PlayerPrefs.GetInt(Saves.SCREEN_RESOLUTION);
    }

    private void SortMaxRefreshRate()
    {
        int newResolutionsLength = 0;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                newResolutionsLength++;
            }
        }

        _resolutions = new Resolution[newResolutionsLength];
        int index = 0;
        _resolutionsDropdown.options.Clear();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                _resolutions[index] = Screen.resolutions[i];

                string option = $"{_resolutions[i].width}x{_resolutions[i].height}";

                _resolutionsDropdown.options.Add(new TMP_Dropdown.OptionData(option));

                index++;
            }
        }
    }

    public void OnChangeResolution(int index)
    {
        Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, PlayerPrefs.GetInt(Saves.IS_FULLSCREEN) == 1);
        PlayerPrefs.SetInt(Saves.SCREEN_RESOLUTION, index);
    }
}
