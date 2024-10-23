using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayFromList : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    [SerializeField] List<AudioClip> tracks;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource soundtrack;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    public void PlayOneRandom()
    {
        int i = UnityEngine.Random.Range(0, clips.Count);
        sfx.PlayOneShot(clips[i]);
    }

    public void ChangeTrack(int trackIndex)
    {
        soundtrack.Stop();
        soundtrack.clip = clips[trackIndex];
        soundtrack.Play();
    }
}
