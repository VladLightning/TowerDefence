using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        AudioListener.volume = volume;
    }

    public void ChangeGameVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
