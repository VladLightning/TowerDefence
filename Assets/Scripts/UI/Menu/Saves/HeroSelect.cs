
using UnityEngine;
using UnityEngine.UI;

public class HeroSelect : MonoBehaviour
{
    [SerializeField] private int _heroIndex;
    private Button _button;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        Save.SaveHero(_heroIndex);
    }
}
