
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private readonly int _audioSourcesCount = 5;
    
    [SerializeField] private SerializedDictionary<AudioEnum, AudioClip> _audioClips;
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
        AudioCaller.OnAudioCall += PlayClip;
    }

    private void OnDisable()
    {
        AudioCaller.OnAudioCall -= PlayClip;
    }

    private void PlayClip(AudioEnum audioType)
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
