
using UnityEngine;

public class GlossaryItemSlotButton : MonoBehaviour
{
    [SerializeField] private GlossaryPageInfoDisplayView _glossaryPageInfoDisplayView;
    
    public void CallDisplayItemInfo(int itemIndex)
    {
        _glossaryPageInfoDisplayView.DisplayItemInfo(itemIndex);
    }
}
