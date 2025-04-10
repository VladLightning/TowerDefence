
using System;
using UnityEngine;

public class GlossaryPagePresenter : MonoBehaviour
{
    public static event Func<GlossaryPageEnum, GlossaryItemData[]> OnGlossaryPageChanged;
    
    [SerializeField] GlossaryPageInfoDisplayView _glossaryPageInfoDisplayView;
    
    private GlossaryPageInfoDisplayView[] _callGlossaryInfoDisplays;

    private void OnEnable()
    {
        SelectPage(GlossaryPageEnum.Towers);
        GlossaryPageView.OnPageSelected += SelectPage;
    }

    private void OnDisable()
    {
        GlossaryPageView.OnPageSelected -= SelectPage;
    }
    
    private void SelectPage(GlossaryPageEnum pageType)
    {
        var pageData = OnGlossaryPageChanged?.Invoke(pageType);
        _glossaryPageInfoDisplayView.DisplayPage(pageData);
    }
}
