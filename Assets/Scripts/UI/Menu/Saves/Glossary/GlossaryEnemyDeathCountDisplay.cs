using TMPro;
using UnityEngine;

public class GlossaryEnemyDeathCountDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _countDisplayPanel;
    [SerializeField] private TMP_Text _countDisplay;
    [SerializeField] private GlossaryPagePresenter _glossaryPagePresenter;
    private GlossaryEnemyDeathCounter _glossaryEnemyDeathCounter;

    private int _currentlySelectedCountDisplay;

    private void Awake()
    {
        _glossaryEnemyDeathCounter = GetComponent<GlossaryEnemyDeathCounter>();
    }

    private void OnEnable()
    {
        UpdateCountDisplay(_currentlySelectedCountDisplay);
    }

    public void CheckSelectedPage()
    {
        _countDisplayPanel.SetActive(_glossaryPagePresenter.CurrentGlossaryPage == GlossaryPageEnum.Enemies);
    }

    public void UpdateCountDisplay(int enemyIndex)
    {
        _currentlySelectedCountDisplay = enemyIndex;
        
        var deathCounterDictionary = _glossaryEnemyDeathCounter.EnemyDeathCounter;
        var enemyCountToShow = _glossaryEnemyDeathCounter.Enemies[enemyIndex];
        
        _countDisplay.text = deathCounterDictionary[enemyCountToShow].ToString();
    }
}
