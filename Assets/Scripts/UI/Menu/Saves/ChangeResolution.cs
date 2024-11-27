using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
public class ChangeResolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionsDropdown;
    
    private readonly List<Resolution> _resolutions = new List<Resolution>();
    
    private void Awake()
    {
        SortMaxRefreshRate();
        _resolutionsDropdown.value = PlayerPrefs.GetInt(Saves.SCREEN_RESOLUTION);
    }

    private void SortMaxRefreshRate()
    {
        var optionsList = new List<string>();
        _resolutionsDropdown.ClearOptions();
        foreach (var resolution in Screen.resolutions)
        {
            if (resolution.refreshRateRatio.value != Screen.currentResolution.refreshRateRatio.value)
            {
                continue;
            }
            _resolutions.Add(resolution);
            optionsList.Add($"{resolution.width}x{resolution.height}");
        }
        _resolutionsDropdown.AddOptions(optionsList);
    }

    public void OnChangeResolution(int index)
    {
        Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, PlayerPrefs.GetInt(Saves.IS_FULLSCREEN) == 1);
        PlayerPrefs.SetInt(Saves.SCREEN_RESOLUTION, index);
    }
}
