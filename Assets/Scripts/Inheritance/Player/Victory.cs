using UnityEngine;

public class Victory : MonoBehaviour
{
    private int _enemiesToDefeat;

    private void OnEnable()
    {
        Spawner.OnIncreaseEnemyAmount += IncreaseEnemiesAmount;
        Enemy.OnDecreaseEnemyAmount += DecreaseEnemyAmount;
    }

    private void OnDisable()
    {
        Spawner.OnIncreaseEnemyAmount -= IncreaseEnemiesAmount;
        Enemy.OnDecreaseEnemyAmount -= DecreaseEnemyAmount;
    }

    private void Win()
    {
        Debug.Log("Victory");
    }

    private void IncreaseEnemiesAmount(int amount)
    {
        _enemiesToDefeat += amount;
    }

    private void DecreaseEnemyAmount()
    {
        _enemiesToDefeat--;
        if(_enemiesToDefeat <= 0)
        {
            Win();
        }
    }
}
