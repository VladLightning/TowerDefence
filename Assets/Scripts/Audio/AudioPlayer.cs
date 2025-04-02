
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private readonly int _audioSourcesCount = 10;
    
    [SerializeField] private SerializedDictionary<AudioEnum.AudioType, AudioClip> _audioClips;
    [SerializeField] private GameObject _audioSourcePrefab;
    
    private AudioSource[] _audioSources;
    
    private void Start()
    {
        for (int i = 0; i < _audioSourcesCount; i++)
        {
            Instantiate(_audioSourcePrefab, transform);
        }
        _audioSources = GetComponentsInChildren<AudioSource>();
    }
    
    private void OnEnable()
    {
        AudioCaller.OnAudioPlayed += PlayClip;
    }

    private void OnDisable()
    {
        AudioCaller.OnAudioPlayed -= PlayClip;
    }

    private void PlayClip(AudioEnum.AudioType audioType)
    {
        var audioSource = GetVacantAudioSource();
        
        if (audioSource == null)
        {
            return;
        }

        audioSource.PlayOneShot(_audioClips[audioType]);
    }

    private AudioSource GetVacantAudioSource()
    {
        return _audioSources.FirstOrDefault(audioSource => !audioSource.isPlaying);
    }
}
