using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButtonsVisual : MonoBehaviour
{
    private readonly float _coinAnimationDuration = 3;

    private readonly float _animationJumpHeight = 10;

    private readonly float _graphicAnimationDuration = 0.1f;

    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private Image[] _buttonImages;

    [SerializeField] private Canvas _targetCanvas;
    [SerializeField] private Transform _target;

    [SerializeField] private GameObject _coin;

    [SerializeField] private Transform _moneyDisplay;

    [SerializeField] private Ease _animationType;

    private Button[] _startWaveButtons;

    private void Start()
    {
        _startWaveButtons = GetComponentsInChildren<Button>();
    }

    private void ActivateSpawners()
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].ActivateSpawner(i);     
        }
    }

    public void SpawnCoinsToAnimate(int index)
    {
        GameObject coin = Instantiate(_coin, _startWaveButtons[index].transform.position, _startWaveButtons[index].transform.rotation);
        coin.GetComponent<TweenAnimation>().StartPointAtoBAnimation(_targetCanvas.worldCamera.ScreenToWorldPoint(_target.position), _animationType, 0, _coinAnimationDuration);

        _moneyDisplay.GetComponent<TweenAnimation>().StartGraphicJump(_coinAnimationDuration, _graphicAnimationDuration, _animationJumpHeight);
    }

    private IEnumerator FillButton(int index, float delay)
    {
        float delayCounter = 0;

        while (delayCounter < delay)
        {
            _buttonImages[index].fillAmount = Mathf.Lerp(0, 1, delayCounter/delay);
            delayCounter += Time.deltaTime;
            yield return null;
        }
        _buttonImages[index].fillAmount = 1;
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
            _startWaveButtons[i].transform.parent.gameObject.SetActive(value);
            if (value)
            {
                StartCoroutine(FillButton(i, delay));
            }            
        }
    }
}
