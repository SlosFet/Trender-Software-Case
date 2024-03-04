using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static float volume { get; private set; }
    private static bool isVolumeChanged;

    private void Start()
    {
        if (!isVolumeChanged)
            volume = 1;

        SetVolume(volume);
    }

    public static void SetVolume(float volume)
    {
        SoundManager.volume = Mathf.Clamp(volume, 0f, 1f);
        AudioListener.volume = volume;
        isVolumeChanged = true;
    }
}
