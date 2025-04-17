
using System;
using UnityEngine;

public class GlossaryPagePresenter : MonoBehaviour
{
    public static event Func<GlossaryPageEnum, GlossaryItemData[]> OnGlossaryPageChanged;

    [SerializeField] private GlossaryEnemyDeathCounterPresenter _glossaryEnemyDeathCounterPresenter;
    [SerializeField] private GlossaryPageInfoDisplayView _glossaryPageInfoDisplayView;
    
    private GlossaryPageInfoDisplayView[] _callGlossaryInfoDisplays;

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
        if (pageType == GlossaryPageEnum.Enemies)
        {
            _glossaryEnemyDeathCounterPresenter.UpdateDisplay(0);
        }

        _glossaryEnemyDeathCounterPresenter.DisplaySetActive(pageType == GlossaryPageEnum.Enemies);
        
        var pageData = OnGlossaryPageChanged?.Invoke(pageType);
        _glossaryPageInfoDisplayView.DisplayPage(pageData);
    }
}
