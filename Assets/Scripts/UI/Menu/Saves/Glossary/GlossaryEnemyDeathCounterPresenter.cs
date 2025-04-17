
using System;
using UnityEngine;

public class GlossaryEnemyDeathCounterPresenter : MonoBehaviour
{
    public static event Action<EnemiesEnum> OnIncreaseDeathCount;
    public static event Func<EnemiesEnum, int> OnUpdateDeathCountDisplay;

    [SerializeField] private GlossaryEnemyDeathCountDisplayView _glossaryEnemyDeathCountDisplayView;

    private int _currentDisplayChosen;
    
    private void Awake()
    {
        Enemy.OnDeathCount += IncreaseModelDeathCount;
    }

    private void OnDestroy()
    {
        Enemy.OnDeathCount -= IncreaseModelDeathCount;
    }

    private void OnEnable()
    {
        if (_glossaryEnemyDeathCountDisplayView.gameObject.activeSelf)
        {
            UpdateDisplay(_currentDisplayChosen);
        }
    }

    public void DisplaySetActive(bool value)
    {
        _glossaryEnemyDeathCountDisplayView.DisplaySetActive(value);
    }
    
    public void UpdateDisplay(int index)
    {
        _currentDisplayChosen = index;
        
        var enemyType = (EnemiesEnum)index;
        int count = (int)OnUpdateDeathCountDisplay?.Invoke(enemyType);
        _glossaryEnemyDeathCountDisplayView.UpdateCountDisplay(count);
    }

    private void IncreaseModelDeathCount(EnemiesEnum enemyType)
    {
        OnIncreaseDeathCount?.Invoke(enemyType);
    }
}
