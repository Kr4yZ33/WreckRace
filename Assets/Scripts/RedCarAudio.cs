using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarAudio : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource audioSource; // Reference to our Audio Source
    public AudioClip idleClip; // reference to our idle clip
    public AudioClip accelerateClip; // reference to our accelerate clip
    public AudioClip brakeClip; // reference to our deceleration clip
    public AudioClip ignitionClip; // reference to our ignition clip
    public AudioClip carSkeletonExplode;
    public AudioClip carSkinExplode;
    public AudioClip carShotClip; // reference to our car shot clip
    //public AudioClip gameMusic1; // reference to our game music
    private AudioClip currentTrack; // the current track being played
    private AudioClip previousTrack; // the previous track that was played
    public float volume = 0.5f; // Reference to the volume of our scare shot clip (plays over game musice that is already playing)
    public float delay = 2;

    void Update()
    {

        if (gameManager.brake == true)
        {
            PlayBrakeClip();
        }

        if (gameManager.accelerate == true)
        {
            PlayAccelerateClip();
        }

        if (gameManager.idle == true)
        {
            PlayIdleClip();
        }
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayCarSkeletonExplode()
    {
        audioSource.PlayOneShot(carSkeletonExplode, volume);
    }

    public void PlayCarShotClip()
    {
        if (currentTrack == carShotClip)
        {
            return;
        }
        audioSource.PlayOneShot(carShotClip, volume);
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayIgnitionClip()
    {
        if (currentTrack == null)
        {
            previousTrack = ignitionClip;
            currentTrack = previousTrack;
            audioSource.PlayOneShot(ignitionClip, volume);
        }
        if (currentTrack == ignitionClip) // if the current track is equal to the ignition sound clip
        {
            Invoke("IgnitionDelay()", 2);
            return;
        }
    }

    public void IgnitionDelay()
    {
        previousTrack = idleClip;
        currentTrack = previousTrack;
        ChangeTrack(currentTrack);
        PlayIdleClip();
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayCarSkinExplode()
    {
        audioSource.PlayOneShot(carSkinExplode, volume);
    }

    /// <summary>
    /// Play break sound clip
    /// </summary>
    void PlayBrakeClip()
    {
        if (currentTrack == brakeClip) // if the current track is equal to the brake sound clip
        {
            return; // exit the script
        }
        if (currentTrack != brakeClip) // if the current track is equal to the brake sound clip
        {
            currentTrack = brakeClip; // set our current track to the brake sound clip
            ChangeTrack(currentTrack); // change the track to our current track
        }
    }

    /// <summary>
    /// Play idle sound clip
    /// </summary>
    void PlayIdleClip()
    {
        if (currentTrack == ignitionClip)
        {
            Invoke("IgnitionDelay()", 2);
        }
        if (currentTrack == idleClip) // if the current track is equal to the idle sound clip
        {
            return;
        }
        if (currentTrack != idleClip) // if the current track is not equal to the idle sound clip
        {
            previousTrack = idleClip;
            currentTrack = previousTrack; // set our current track to the idle sound clip
            ChangeTrack(currentTrack); // change the track to our current track
        }
    }

    /// <summary>
    /// Plays accelerate sound clip
    /// </summary>
    void PlayAccelerateClip()
    {
        if (currentTrack == accelerateClip)  // if the current track is equal to the accelerate sound clip
        {
            return; // exit the script
        }
        if (currentTrack != accelerateClip)  // if the current track is not equal to the accelerate sound clip
        {
            previousTrack = accelerateClip;
            currentTrack = previousTrack; // set our current track to the accelerate sound clip
            ChangeTrack(currentTrack); // change the track to our current track
        }
    }

    /// <summary>
    /// play the previous track that was being played
    /// </summary>
    public void PlayPreviousTrack()
    {
        // if there is no previous track
        if (previousTrack == null)
        {
            previousTrack = ignitionClip;
        }
        currentTrack = previousTrack; // set the current track to the previous track
        ChangeTrack(currentTrack); // play our previous track
    }

    /// <summary>
    /// play the previous track that was being played
    /// </summary>
    void StopTrack()
    {
        // if there is a previous track
        if (previousTrack != null)
        {
            previousTrack = null;
        }
        currentTrack = previousTrack; // set the current track to the previous track
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
