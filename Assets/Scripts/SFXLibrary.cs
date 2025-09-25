using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLibrary: MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundMap;

    private void Awake()
    {
        InitializeMap();
    }

    private void InitializeMap()
    {
        soundMap = new Dictionary<string, List<AudioClip>>();

        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundMap[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundMap.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundMap[name];
            if (audioClips.Count > 1)
            {
                return audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
            }
            return audioClips[0];
        }
        return null;
    }

}

[Serializable]
public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> audioClips;
}

