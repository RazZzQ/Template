using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "ScriptableObjects/AudioData", order = 0)]

public class AudioData : ScriptableObject
{
    public AudioMixer audioMixer;
    public AudioMixerGroup musicMixerGroup;
    public AudioMixerGroup sfxMixerGroup;

    [Range(0f, 1f)] public float musicVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 0.5f;

    public AudioClip defaultMusicClip;
    public AudioClip[] soundEffects;
}
