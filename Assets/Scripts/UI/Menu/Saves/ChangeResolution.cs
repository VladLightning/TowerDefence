using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;

[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
public class ChangeResolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionsDropdown;
    
    private Resolution[] _resolutions;
    private readonly List<string> _optionsList = new List<string>();
    
    private void Awake()
    {
        SortMaxRefreshRate();
        _resolutionsDropdown.value = PlayerPrefs.GetInt(Saves.SCREEN_RESOLUTION);
    }

    private void SortMaxRefreshRate()
    {
        int newResolutionsLength = 0;
        foreach (var resolution in Screen.resolutions)
        {
            if (resolution.refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            {
                newResolutionsLength++;
            }
        }

        _resolutions = new Resolution[newResolutionsLength];
        int index = 0;
        _resolutionsDropdown.options.Clear();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value != Screen.currentResolution.refreshRateRatio.value)
            {
                continue;
            }
            
            _resolutions[index] = Screen.resolutions[i];

            string option = $"{_resolutions[i].width}x{_resolutions[i].height}";

            _optionsList.Add(option);
            
            index++;
        }
        _resolutionsDropdown.AddOptions(_optionsList);
    }

    public void OnChangeResolution(int index)
    {
        Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, PlayerPrefs.GetInt(Saves.IS_FULLSCREEN) == 1);
        PlayerPrefs.SetInt(Saves.SCREEN_RESOLUTION, index);
    }
}
