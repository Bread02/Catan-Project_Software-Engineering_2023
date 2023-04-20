using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
    public AudioMixerGroup group;
    public bool loop;
    [Range(0f, 1f)] public float volume;

    [HideInInspector]
    public AudioSource audioSource;
}
