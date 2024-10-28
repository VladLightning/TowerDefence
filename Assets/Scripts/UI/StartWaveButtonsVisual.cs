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

    [SerializeField] private GameObject _moneyDisplay;

    [SerializeField] private Ease _animationType;

    [SerializeField] private PathType _pathType;
    [SerializeField] private PathMode _pathMode;
    [SerializeField] private int _resolution;

    [SerializeField] private Transform _animationCurvePoints;

    [SerializeField] private TweenAnimation _animator;

    private Button[] _startWaveButtons;

    private void Awake()
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

    public IEnumerator SpawnCoinsToAnimate(int index)
    {
        GameObject coin = Instantiate(_coin, _startWaveButtons[index].transform.position, _startWaveButtons[index].transform.rotation);

        Vector3[] path = {_startWaveButtons[index].transform.position, _animationCurvePoints.GetChild(index).position, _targetCanvas.worldCamera.ScreenToWorldPoint(_target.position)};

        _animator.StartCoroutine(_animator.PointAtoZCurve(coin.transform, path, _animationType, _pathType, _pathMode, _resolution, 0, _coinAnimationDuration));

        yield return _animator.StartCoroutine(_animator.GraphicJump(_moneyDisplay.transform, _coinAnimationDuration, _graphicAnimationDuration, _animationJumpHeight));
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
        SetActiveAllButtons(false);
        ActivateSpawners();
    }

    private void SetActiveAllButtons(bool value)
    {
        for (int i = 0; i < _startWaveButtons.Length; i++)
        {
            _startWaveButtons[i].transform.parent.gameObject.SetActive(value);
        }
    }

    public void SetButtonsActive(bool value, int buttonIndex, bool fill = true)
    {
        float delay = _spawners[0].CurrentWaveDelay;
        _startWaveButtons[buttonIndex].transform.parent.gameObject.SetActive(value);
        if (value && fill)
        {
            StartCoroutine(FillButton(buttonIndex, delay));
        }
    }
}
