
using System;

public class AudioCaller
{
    public static event Action<AudioEnum> OnAudioCall;
    
    public static void PlayAudio(AudioEnum audioType)
    {
        OnAudioCall?.Invoke(audioType);
    }
}
