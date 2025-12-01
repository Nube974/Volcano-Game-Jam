using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    CLICK,
    COLLECT,
    DYING,
    GROWING,
    HURT,
    PAUSE,
    RUN,
    SHRINKING,
    SWOOSH,
    VICTORY,
    WAVE
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class S_SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    public static S_SoundManager instance;
    private AudioSource audioSource;

    

    private void Awake()
    { 
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
        // instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, name.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
 
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds {get => sounds;}
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
