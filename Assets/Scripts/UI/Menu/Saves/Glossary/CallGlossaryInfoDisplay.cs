
using UnityEngine;
using UnityEngine.UI;

public class CallGlossaryInfoDisplay : MonoBehaviour
{
    [SerializeField] private GlossaryEnum _item;
    
    private Image _image;
    private Button _button;
    private Glossary _glossary;

    private void Start()
    {
        _image = GetComponent<Image>();
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallGlossaryDisplayInfo);
        
        _glossary = GetComponentInParent<Glossary>();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(CallGlossaryDisplayInfo);
    }

    private void CallGlossaryDisplayInfo()
    {
        _glossary.DisplayInfo(_item);
    }

    public void SetItem(GlossaryEnum item)
    {
        _item = item;
        _image.sprite = _glossary.GlossaryDatabase.Items[_item].ItemIcon;
    }
}
