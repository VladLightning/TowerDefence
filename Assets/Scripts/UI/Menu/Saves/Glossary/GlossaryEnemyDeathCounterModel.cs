
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class GlossaryEnemyDeathCounterModel : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<EnemiesEnum, int> _enemyDeathCounter;

    private void Start()
    {
        _enemyDeathCounter = Save.GetSavedDeathCounts();
    }

    private void Awake()
    {
        GlossaryEnemyDeathCounterPresenter.OnIncreaseDeathCount += IncreaseDeathCount;
        GlossaryEnemyDeathCounterPresenter.OnUpdateDeathCountDisplay += GetDeathCount;
        Victory.OnVictory += SaveDeathCounts;
    }

    private void OnDestroy()
    {
        GlossaryEnemyDeathCounterPresenter.OnIncreaseDeathCount -= IncreaseDeathCount;
        GlossaryEnemyDeathCounterPresenter.OnUpdateDeathCountDisplay -= GetDeathCount;
        Victory.OnVictory -= SaveDeathCounts;
    }

    private void SaveDeathCounts()
    {
        Save.SaveEnemiesDeathCounts(_enemyDeathCounter);
    }

    private void IncreaseDeathCount(EnemiesEnum enemyType)
    {
        _enemyDeathCounter[enemyType]++;
    }

    private int GetDeathCount(EnemiesEnum enemyType)
    {
        return _enemyDeathCounter[enemyType];
    }
}
