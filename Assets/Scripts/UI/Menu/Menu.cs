
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    public void Open()
    {
        _gameMenu.SetActive(!_gameMenu.activeSelf);
    }
}
