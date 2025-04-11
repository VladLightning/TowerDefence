using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryPageInfoDisplayView : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _itemStats;
    
    [SerializeField] private Image[] _itemSlotsIcons;

    private GlossaryItemData[] _currentPageData;

    public void DisplayPage(GlossaryItemData[] glossaryItems)
    {
        _currentPageData = glossaryItems;
        
        DisplayItemInfo(0);
        
        for (int i = 0; i < glossaryItems.Length; i++)
        {
            _itemSlotsIcons[i].sprite = glossaryItems[i].ItemIcon;
            _itemSlotsIcons[i].gameObject.SetActive(true);
        }
        
        for (int i = _currentPageData.Length; i < _itemSlotsIcons.Length; i++)
        {
            _itemSlotsIcons[i].gameObject.SetActive(false);
        }
    }

    public void DisplayItemInfo(int itemIndex)
    {
        _itemIcon.sprite = _currentPageData[itemIndex].ItemIcon;
        _itemName.text = _currentPageData[itemIndex].ItemName;
        _itemDescription.text = _currentPageData[itemIndex].ItemDescription;
        _itemStats.text = _currentPageData[itemIndex].ItemStats;
    }
}
