using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource source;
    public List<AudioClip> audioClips;
    public Dictionary<string, AudioClip> cliptionary;
    void Start()
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            AudioClip clip = audioClips[i];
            string clipName = clip.name;
            cliptionary.Add(clipName, clip);
        }
    }

    void PlayAudioClip(string clipName)
    {
        AudioClip clip = cliptionary[clipName];
        source.PlayOneShot(clip);
    }
    public void OnShipMove()
    {
        PlayAudioClip("shipMove");
    }
    public void OnShipStop()
    {
        PlayAudioClip("shipStop");
    }
    public void OnShipHit()
    {
        PlayAudioClip("shipHit");
    }
    public void OnDoorOpen()
    {
        PlayAudioClip("doorOpen");
    }
    public void OnShoot()
    {
        PlayAudioClip("shoot");
    }
    public void OnPopUp()
    {
        PlayAudioClip("popUp");
    }
    public void OnExplosion()
    {
        PlayAudioClip("explosion");
    }
    public void OnBuy()
    {
        PlayAudioClip("buy");
    }
    public void OnSell()
    {
        PlayAudioClip("sell");
    }
    public void OnPositiveButtonPress()
    {
        PlayAudioClip("positiveButton");
    }
    public void OnNeutralButtonPress()
    {
        PlayAudioClip("neutralButton");
    }
    public void OnNegativeEvent()
    {
        PlayAudioClip("negativeBuzzer");
    }
}
