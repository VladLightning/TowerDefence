

using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryDatabase : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _itemStats;
    
    [SerializeField] private SerializedDictionary<GlossaryEnum, GlossaryItemData> _items;
    public SerializedDictionary<GlossaryEnum, GlossaryItemData> Items => _items;
    
    [SerializeField] private GlossaryPage _defaultPage;
    
    private GlossaryPageDisplay _glossaryPageDisplay;

    private void Start()
    {
        _glossaryPageDisplay = GetComponent<GlossaryPageDisplay>();
    }

    public void DisplayDefaultPage()
    {
        DisplayInfo(_defaultPage.PageItems[0]);
        _glossaryPageDisplay.DisplayPage(_defaultPage.PageItems);
    }

    public void DisplayInfo(GlossaryEnum item)
    {
        _itemIcon.sprite = _items[item].ItemIcon;
        _itemName.text = _items[item].ItemName;
        _itemDescription.text = _items[item].ItemDescription;
        _itemStats.text = _items[item].ItemStats;
    }
}
