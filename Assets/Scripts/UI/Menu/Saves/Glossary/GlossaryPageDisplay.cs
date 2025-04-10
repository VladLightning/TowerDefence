
using UnityEngine;

public class GlossaryPageDisplay : MonoBehaviour
{
    [SerializeField] private Transform _itemsDisplayPage;
    public Transform ItemsDisplayPage => _itemsDisplayPage;
    
    private CallGlossaryInfoDisplay[] _callGlossaryInfoDisplays;

    private void Start()
    {
        _callGlossaryInfoDisplays = _itemsDisplayPage.GetComponentsInChildren<CallGlossaryInfoDisplay>();
        GetComponent<GlossaryDatabase>().DisplayDefaultPage();
    }
    
    public void DisplayPage(GlossaryEnum[] pageItems)
    {
        foreach (var itemSlot in _callGlossaryInfoDisplays)
        {
            itemSlot.gameObject.SetActive(false);
        }

        for (int i = 0; i < pageItems.Length; i++)
        {
            _callGlossaryInfoDisplays[i].gameObject.SetActive(true);
            _callGlossaryInfoDisplays[i].SetItem(pageItems[i]);
        }
    }
}
