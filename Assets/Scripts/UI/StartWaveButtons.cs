using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButtons : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    private Button[] _startWaveButtons;

    private void Start()
    {
        _startWaveButtons = GetComponentsInChildren<Button>();
    }

    private void ActivateSpawners()
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].ActivateSpawner();         
        }
    }

    private IEnumerator FillButton(int index, float delay)
    {
        Image buttonImage = _startWaveButtons[index].GetComponent<Image>();
        float delayCounter = 0;

        while (delayCounter < delay)
        {
            buttonImage.fillAmount = Mathf.Lerp(0, 1, delayCounter/delay);
            delayCounter += Time.deltaTime;
            yield return null;
        }      
        buttonImage.fillAmount = 1;
    }

    public void OnClick()
    {
        SetButtonsActive(false);
        ActivateSpawners();
    }

    public void SetButtonsActive(bool value)
    {
        float delay = _spawners[0].CurrentWaveDelay;
        for (int i = 0; i < _startWaveButtons.Length; i++)
        {
            _startWaveButtons[i].gameObject.SetActive(value);
            if (value)
            {
                StartCoroutine(FillButton(i, delay));
            }            
        }
    }
}
