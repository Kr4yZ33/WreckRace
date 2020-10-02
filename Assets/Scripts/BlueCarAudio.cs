using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarAudio : MonoBehaviour
{
    public XRInputs xRInputs;
    public AudioSource audioSource; // Reference to our Audio Source
    public AudioClip idleClip; // reference to our idle clip
    public AudioClip accelerateClip; // reference to our accelerate clip
    public AudioClip brakeClip; // reference to our deceleration clip
    public AudioClip ignitionClip; // reference to our ignition clip
    public AudioClip carSkeletonExplode;
    public AudioClip carSkinExplode;
    //public AudioClip gameMusic1; // reference to our game music
    private AudioClip currentTrack; // the current track being played
    private AudioClip previousTrack; // the previous track that was played
    public float volume = 0.5f; // Reference to the volume of our scare shot clip (plays over game musice that is already playing)
    public float delay = 2;

    /// <summary>
    /// This gets called everytime the script gets turned off/on
    /// </summary>
    public void OnEnable()
    {
        if(xRInputs.usingCarBlue == true)
        {
            if (currentTrack == null)
            {
                audioSource.PlayOneShot(ignitionClip);
            }
        }
        
    }

    private void Update()
    {
        if (currentTrack == ignitionClip)
        {
            return;
        }
        else if (currentTrack == idleClip) // if the current track is equal to the idle sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            currentTrack = idleClip; // set our current track to the brake sound clip
            ChangeTrack(currentTrack); // change the track to our current track
        }
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayCarSkeletonExplode()
    {
        if (currentTrack == carSkeletonExplode) // if the current track is equal to the brake sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            audioSource.PlayOneShot(carSkeletonExplode, volume);
        }
    }

    /// <summary>
    /// Play car skeleton exploding sound clip
    /// </summary>
    public void PlayCarSkinExplode()
    {
        if (currentTrack == carSkinExplode) // if the current track is equal to the brake sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            audioSource.PlayOneShot(carSkinExplode, volume);
        }
    }

    /// <summary>
    /// Play break sound clip
    /// </summary>
    public void PlayCarIgnitionClip()
    {
        if (currentTrack == ignitionClip) // if the current track is equal to the brake sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            audioSource.PlayOneShot(ignitionClip);
        }
    }


    /// <summary>
    /// Play break sound clip
    /// </summary>
    public void PlayBrakeClip()
    {
        if (currentTrack == brakeClip) // if the current track is equal to the brake sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            currentTrack = brakeClip; // set our current track to the brake sound clip
            ChangeTrack(currentTrack); // change the track to our current track
        }
    }

    /// <summary>
    /// Play idle sound clip
    /// </summary>
    public void PlayIdleClip()
    {
        if (currentTrack != ignitionClip)
        {
            if (currentTrack == idleClip) // if the current track is equal to the idle sound clip
            {
                return; // exit the script
            }
            else // otherwise
            {
                currentTrack = idleClip; // set our current track to the idle sound clip
                ChangeTrack(currentTrack); // change the track to our current track
            }
        }
    }

    /// <summary>
    /// Plays accelerate sound clip
    /// </summary>
    public void PlayAccelerateClip()
    {
        if (currentTrack == accelerateClip)  // if the current track is equal to the accelerate sound clip
        {
            return; // exit the script
        }
        else // otherwise
        {
            currentTrack = accelerateClip; // set our current track to the accelerate sound clip
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
            previousTrack = idleClip;
        }
        currentTrack = previousTrack; // set the current track to the previous track
        ChangeTrack(currentTrack); // play our previous track
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
