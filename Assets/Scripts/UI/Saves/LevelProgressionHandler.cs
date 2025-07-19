using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionHandler : MonoBehaviour
{
    private Button[] _levelButtons;

    private void Start()
    {
        _levelButtons = GetComponentsInChildren<Button>();
        
        ActivateLevelButtons();
    }

    private void ActivateLevelButtons()
    {
        int latestCompletedLevelIndex = Save.GetSavedLatestCompletedLevelIndex();
        latestCompletedLevelIndex = 
            latestCompletedLevelIndex == _levelButtons.Length ? _levelButtons.Length - 1 : latestCompletedLevelIndex;

        for (int i = 0; i <= latestCompletedLevelIndex; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
