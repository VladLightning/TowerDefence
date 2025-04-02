using System.Collections;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private readonly float _winPanelActivationDelay = 3;
    
    [SerializeField] private GameObject _winPanel;
    private int _enemiesToDefeat;

    private void OnEnable()
    {
        Spawner.OnIncreaseEnemyAmount += IncreaseEnemiesAmount;
        Enemy.OnDecreaseEnemyAmount += DecreaseEnemyAmount;

        Slime.OnSplit += IncreaseEnemiesAmount;
    }

    private void OnDisable()
    {
        Spawner.OnIncreaseEnemyAmount -= IncreaseEnemiesAmount;
        Enemy.OnDecreaseEnemyAmount -= DecreaseEnemyAmount;
        
        Slime.OnSplit -= IncreaseEnemiesAmount;
    }

    private IEnumerator Win()
    {
        AudioCaller.PlayAudio(AudioEnum.AudioType.Victory);
        yield return new WaitForSeconds(_winPanelActivationDelay);
        _winPanel.SetActive(true);
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
            StartCoroutine(Win());
        }
    }
}
