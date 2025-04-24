
using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowPresenter : MonoBehaviour
{
    public static event Action<float> OnWindowSetActive;
    
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
        
        OnWindowSetActive?.Invoke(0);
    }

    public void RemoveWindow(GameObject window)
    { 
        window.SetActive(false);
        _windowList.Remove(window);

        DisablePause();
    }

    public void RemoveWindow()
    {
        _windowList[^1].SetActive(false);
        _windowList.RemoveAt(_windowList.Count - 1);
        
        DisablePause();
    }
    
    private void DisablePause()
    {
        if (!IsWindowOpen)
        {
            OnWindowSetActive?.Invoke(1);
        }
    }
}
