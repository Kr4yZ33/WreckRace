﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoxAudio : MonoBehaviour
{
    public GameManager gameManager;
    bool isMusicPaused = false;

    public AudioSource audioSource; // Reference to our Audio Source
    public AudioClip gameClip1; // reference to our game clip1
    public AudioClip gameClip2; // reference to our game clip2
    public AudioClip gameClip3; // reference to our game clip3
    public AudioClip trackExplodeClip; // reference to our track explode clip
    private AudioClip currentTrack; // the current track being played
    private AudioClip previousTrack; // the previous track that was played
    public float volume = 0.5f; // Reference to the volume of our scare shot clip (plays over game musice that is already playing)
    public float delay = 2;

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayTrackExplode()
    {
        audioSource.PlayOneShot(trackExplodeClip, volume);
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayGameClip1()
    {
        if (currentTrack == null)
        {
            previousTrack = gameClip1;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip2()
    {
        previousTrack = gameClip2;
        currentTrack = previousTrack;
        ChangeTrack(currentTrack);
    }

    public void PlayGameClip3()
    {
        previousTrack = gameClip3;
        currentTrack = previousTrack;
        ChangeTrack(currentTrack);
    }

    /// <summary>
    /// play the previous track that was being played
    /// </summary>
    public void PlayPreviousTrack()
    {
        // if there is no previous track
        if (previousTrack == null)
        {
            previousTrack = gameClip1;
        }
        currentTrack = previousTrack; // set the current track to the previous track
        ChangeTrack(currentTrack); // play our previous track
        volume = 0;
    }

    public void NextTrack()
    {
        if (isMusicPaused == true)
        {
            PlayGameClip1();
            isMusicPaused = false;
        }
        if (currentTrack == gameClip3)
        {
            previousTrack = null;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
            isMusicPaused = true;
        }
        if (currentTrack == gameClip2)
        {
            PlayGameClip3();
        }
        if (currentTrack == gameClip1)
        {
            PlayGameClip2();
        }
        if(currentTrack == null)
        {
            PlayGameClip1();
        }
    }

    /// <summary>
    /// This function changes the clip being played at the moment
    /// </summary>
    /// <param name="clip"></param>
    public void ChangeTrack(AudioClip clip)
    {
        audioSource.Stop(); // stop playing the current clip
        if (audioSource.clip != clip) // if the current clip in the audio source is not equal to the clip we are trying to play
        {
            previousTrack = audioSource.clip; // store the previous track
            audioSource.clip = clip; // set the new track
        }
        audioSource.loop = true; // set the track to be looping
        audioSource.Play(); // start playing our music
    }
}