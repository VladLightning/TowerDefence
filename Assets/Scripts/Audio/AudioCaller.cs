
using System;

public class AudioCaller
{
    public static event Action<AudioEnum.AudioType> OnAudioPlayed;
    
    public static void PlayAudio(AudioEnum.AudioType audioType)
    {
        OnAudioPlayed?.Invoke(audioType);
    }
}
