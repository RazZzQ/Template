using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action OnSceneLoaded;
    public static Action<float> OnVolumeChanged;

    public static void SceneLoaded()
    {
        OnSceneLoaded?.Invoke();
    }

    public static void VolumeChanged(float newVolume)
    {
        OnVolumeChanged?.Invoke(newVolume);
    }
}
