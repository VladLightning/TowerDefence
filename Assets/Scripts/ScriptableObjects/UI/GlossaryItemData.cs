
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Glossary/ItemData")]
public class GlossaryItemData : ScriptableObject
{
    [SerializeField] private Sprite _itemIcon;
    public Sprite ItemIcon => _itemIcon;
    [SerializeField] private string _itemName;
    public string ItemName => _itemName;
    [TextArea(5,10)]
    [SerializeField] private string _itemDescription;
    public string ItemDescription => _itemDescription;
    [TextArea(5,10)]
    [SerializeField] private string _itemStats;
    public string ItemStats => _itemStats;
}
