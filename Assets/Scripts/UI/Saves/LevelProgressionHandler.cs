using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionHandler : MonoBehaviour
{
    private Button[] _levelButtons;

    private int _latestCompletedLevelIndex;

    private void Start()
    {
        _levelButtons = GetComponentsInChildren<Button>();
        _latestCompletedLevelIndex = Save.GetSavedLatestCompletedLevelIndex();
        
        ActivateLevelButtons();
    }

    private void ActivateLevelButtons()
    {
        if (_latestCompletedLevelIndex == _levelButtons.Length)
        {
            _latestCompletedLevelIndex--;
        }
        for (int i = 0; i <= _latestCompletedLevelIndex; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
