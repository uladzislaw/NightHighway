using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    public List<GameObject> musicTracks;
    private int index;

    private GameObject currentTrack;

    private void Start()
    {
        index = Random.Range(0, musicTracks.Capacity);
        currentTrack = musicTracks[index];
        currentTrack.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
           switchTrack();
        }

        if (!currentTrack.GetComponent<AudioSource>().isPlaying)
        {
            index = Random.Range(0, musicTracks.Capacity);
            currentTrack.SetActive(false);
            currentTrack = musicTracks[index];
            currentTrack.SetActive(true);
        }
        

    }

    public void switchTrack()
    {
        index = Random.Range(0, musicTracks.Capacity);
        currentTrack.SetActive(false);
        currentTrack = musicTracks[index];
        currentTrack.SetActive(true);
    }
}
    
    