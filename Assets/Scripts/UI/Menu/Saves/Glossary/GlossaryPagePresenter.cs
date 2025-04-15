
using System;
using UnityEngine;

public class GlossaryPagePresenter : MonoBehaviour
{
    public static event Func<GlossaryPageEnum, GlossaryItemData[]> OnGlossaryPageChanged;

    [SerializeField] private GlossaryEnemyDeathCountDisplay _glossaryEnemyDeathCountDisplay;
    
    [SerializeField] private GlossaryPageInfoDisplayView _glossaryPageInfoDisplayView;
    
    private GlossaryPageInfoDisplayView[] _callGlossaryInfoDisplays;
    
    private GlossaryPageEnum _currentGlossaryPage;
    public GlossaryPageEnum CurrentGlossaryPage => _currentGlossaryPage;

    private void Start()
    {
        SelectPage(GlossaryPageEnum.Towers);
    }

    private void OnEnable()
    {
        GlossaryPageView.OnPageSelected += SelectPage;
    }

    private void OnDisable()
    {
        GlossaryPageView.OnPageSelected -= SelectPage;
    }
    
    private void SelectPage(GlossaryPageEnum pageType)
    {
        _currentGlossaryPage = pageType;
        _glossaryEnemyDeathCountDisplay.CheckSelectedPage();
        _glossaryEnemyDeathCountDisplay.UpdateCountDisplay(0);
        
        var pageData = OnGlossaryPageChanged?.Invoke(pageType);
        _glossaryPageInfoDisplayView.DisplayPage(pageData);
    }
}
