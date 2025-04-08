

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
    [SerializeField] private GlossaryEnum _defaultItem;

    private void Start()
    {
        DisplayInfo(_defaultItem);
    }

    public void DisplayInfo(GlossaryEnum item)
    {
        _itemIcon.sprite = _items[item].ItemIcon;
        _itemName.text = _items[item].ItemName;
        _itemDescription.text = _items[item].ItemDescription;
        _itemStats.text = _items[item].ItemStats;
    }
}
