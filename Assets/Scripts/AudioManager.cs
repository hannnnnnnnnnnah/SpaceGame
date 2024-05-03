using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource source;
    public List<AudioClip> audioClips;
    public Dictionary<string, AudioClip> cliptionary = new Dictionary<string, AudioClip>();
    void Start()
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            AudioClip clip = audioClips[i];
            string clipName = clip.name;
            cliptionary.Add(clipName, clip);
        }
    }

    [PunRPC]
    void PlayAudioClip(string clipName)
    {
        AudioClip clip = cliptionary[clipName];
        source.PlayOneShot(clip);
    }
}
