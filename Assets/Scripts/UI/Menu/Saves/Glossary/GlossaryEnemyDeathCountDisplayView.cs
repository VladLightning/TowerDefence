using TMPro;
using UnityEngine;

public class GlossaryEnemyDeathCountDisplayView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDisplay;

    public void DisplaySetActive(bool value)
    {
        gameObject.SetActive(value);
    }
    
    public void UpdateCountDisplay(int count)
    {
        _countDisplay.text = "Deaths:" + count;
    }
}
