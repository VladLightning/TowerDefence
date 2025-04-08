
using UnityEngine;
using UnityEngine.UI;

public class CallGlossaryInfoDisplay : MonoBehaviour
{
    [SerializeField] private GlossaryEnum _item;
    
    private Button _button;
    private Glossary _glossary;

    private void Start()
    {
        _button = GetComponent<Button>();
        _glossary = GetComponentInParent<Glossary>();
        
        _button.onClick.AddListener(CallGlossaryDisplayInfo);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(CallGlossaryDisplayInfo);
    }

    private void CallGlossaryDisplayInfo()
    {
        _glossary.DisplayInfo(_item);
    }
}
