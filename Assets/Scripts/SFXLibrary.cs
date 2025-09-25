using System.Collections.Generic;
using UnityEngine;

public class SFXLibrary: MonoBehaviour
{
    public SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundMap;

    private void Awake()
    {
        InitializeMap();
    }

    private void InitializeMap()
    {
        soundMap = new Dictionary<string, List<AudioClip>>();

        foreach (SoundEffectGroup group in soundEffectGroups)
        {
            soundMap[group.name] = group.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundMap.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundMap[name];
            if (audioClips.Count > 1)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
            return audioClips[0];
        }
        return null;
    }

}

[SerializeField]
public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> audioClips;
}

