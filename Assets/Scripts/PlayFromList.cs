using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayFromList : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void PlayOneRandom()
    {
        int i = Random.Range(0, clips.Count);
        AudioSource.PlayOneShot(clips[i]);
    }
}
