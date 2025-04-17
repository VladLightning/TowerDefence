
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class GlossaryEnemyDeathCounterModel : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<EnemiesEnum, int> _enemyDeathCounter;

    private void Awake()
    {
        GlossaryEnemyDeathCounterPresenter.OnIncreaseDeathCount += IncreaseDeathCount;
        GlossaryEnemyDeathCounterPresenter.OnUpdateDeathCountDisplay += GetDeathCount;
    }

    private void OnDestroy()
    {
        GlossaryEnemyDeathCounterPresenter.OnIncreaseDeathCount -= IncreaseDeathCount;
        GlossaryEnemyDeathCounterPresenter.OnUpdateDeathCountDisplay -= GetDeathCount;
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
