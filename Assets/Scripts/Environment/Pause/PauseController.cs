
using System;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private void OnEnable()
    {
        WindowPresenter.OnWindowSetActive += Pause;
    }

    private void OnDisable()
    {
        WindowPresenter.OnWindowSetActive -= Pause;
    }

    private void Pause(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
