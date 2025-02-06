
using TMPro;
using UnityEngine;

public class UpgradeDescriptionDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _descriptionText;
    
    [SerializeField] private BranchUpgradesHandler _branchUpgradesHandler;

    public void ShowDescription(int upgradeIndex)
    {
        _descriptionText.text = _branchUpgradesHandler.GetUpgradeDescription(upgradeIndex);
        gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        gameObject.SetActive(false);
    }
}
