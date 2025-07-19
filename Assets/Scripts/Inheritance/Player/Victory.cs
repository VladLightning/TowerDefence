using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private readonly float _winPanelActivationDelay = 3;

    public static event Action OnVictory;
    
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
        AudioCaller.PlayAudio(AudioEnum.Victory);
        yield return new WaitForSeconds(_winPanelActivationDelay);
        _winPanel.SetActive(true);
        
        Save.SaveCompletedLevelIndex(SceneManager.GetActiveScene().buildIndex);
        
        OnVictory?.Invoke();
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
