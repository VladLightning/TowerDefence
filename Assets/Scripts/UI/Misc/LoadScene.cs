
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;
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
        SceneManager.LoadScene(_sceneName);
    }
}
