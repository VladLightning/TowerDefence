
using System;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryPageView : MonoBehaviour
{
    public static event Action<GlossaryPageEnum> OnPageSelected;
    
    [SerializeField] private GlossaryPageEnum _pageType;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallPageDisplay);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(CallPageDisplay);
    }
    
    private void CallPageDisplay()
    {
        OnPageSelected?.Invoke(_pageType);
    }
}
