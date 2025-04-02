
using UnityEngine;
using UnityEngine.UI;

public class OnClickAudio : MonoBehaviour
{
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
        AudioCaller.PlayAudio(AudioEnum.AudioType.Click);
    }
}
