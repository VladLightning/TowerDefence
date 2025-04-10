
using UnityEngine;
using UnityEngine.UI;

public class GlossaryPage : MonoBehaviour
{
    [SerializeField] private GlossaryEnum[] _pageItems;
    public GlossaryEnum[] PageItems => _pageItems;
    
    private GlossaryPageDisplay _glossaryPageDisplay;

    private Button _button;

    private void Awake()
    {
        _glossaryPageDisplay = GetComponentInParent<GlossaryPageDisplay>();
        
        AdjustGlossaryItemSlotsAmount();
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallPageDisplay);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(CallPageDisplay);
    }

    private void AdjustGlossaryItemSlotsAmount()
    {
        if (_pageItems.Length > _glossaryPageDisplay.ItemsDisplayPage.childCount)
        {
            int childrenToCloneAmount = _pageItems.Length - _glossaryPageDisplay.ItemsDisplayPage.childCount;
            for (int i = 0; i < childrenToCloneAmount; i++)
            {
                Instantiate(_glossaryPageDisplay.ItemsDisplayPage.GetChild(0), _glossaryPageDisplay.ItemsDisplayPage);
            }
        }
    }

    private void CallPageDisplay()
    {
        _glossaryPageDisplay.DisplayPage(_pageItems);
    }
}
