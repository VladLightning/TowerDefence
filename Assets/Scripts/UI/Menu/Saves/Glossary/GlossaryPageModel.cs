
using System;
using UnityEngine;
public class GlossaryPageModel : MonoBehaviour
{
    [SerializeField] private GlossaryItemData[] _towerInfo;
    [SerializeField] private GlossaryItemData[] _heroInfo;
    [SerializeField] private GlossaryItemData[] _abilityInfo;
    [SerializeField] private GlossaryItemData[] _enemyInfo;

    private void OnEnable()
    {
        GlossaryPagePresenter.OnGlossaryPageChanged += GetGlossaryDataByType;
    }

    private void OnDisable()
    {
        GlossaryPagePresenter.OnGlossaryPageChanged -= GetGlossaryDataByType;
    }

    private GlossaryItemData[] GetGlossaryDataByType(GlossaryPageEnum pageType)
    {
        return pageType switch
        {
            GlossaryPageEnum.Towers => _towerInfo,
            GlossaryPageEnum.Heroes => _heroInfo,
            GlossaryPageEnum.Abilities => _abilityInfo,
            GlossaryPageEnum.Enemies => _enemyInfo,
            _ => throw new ArgumentException($"Нет такого значения в enum {nameof(GlossaryPageEnum)}: {pageType}")
        };
    }
}
