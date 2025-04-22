
using System.Collections.Generic;
using UnityEngine;

public class WindowPresenter : MonoBehaviour
{
    private List<GameObject> _windowList = new List<GameObject>();
    
    public bool IsWindowOpen => _windowList.Count > 0;
    
    public void AddWindow(GameObject window)
    {
        if (_windowList.Contains(window))
        {
            return;
        }
        window.SetActive(true);
        _windowList.Add(window);
    }

    public void RemoveWindow(GameObject window)
    { 
        window.SetActive(false);
        _windowList.Remove(window);
    }

    public void RemoveWindow()
    {
        _windowList[^1].SetActive(false);
        _windowList.RemoveAt(_windowList.Count - 1);
    }
}
