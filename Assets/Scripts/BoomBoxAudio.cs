using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoxAudio : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource audioSource; // Reference to our Audio Source
    public AudioClip gameClip1; // reference to our game clip1
    public AudioClip gameClip2; // reference to our game clip2
    public AudioClip gameClip3; // reference to our game clip3
    public AudioClip gameClip4; // reference to our game clip4
    public AudioClip gameClip5; // reference to our game clip5
    public AudioClip gameClip6; // reference to our game clip6
    public AudioClip gameClip7; // reference to our game clip7
    public AudioClip gameClip8; // reference to our game clip8
    public AudioClip gameClip9; // reference to our game clip9
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
        if (currentTrack != gameClip1)
        {
            previousTrack = gameClip1;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip2()
    {
        if (currentTrack != gameClip2)
        {
            previousTrack = gameClip2;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip3()
    {
        if (currentTrack != gameClip3)
        {
            previousTrack = gameClip3;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip4()
    {
        if (currentTrack != gameClip4)
        {
            previousTrack = gameClip4;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip5()
    {
        if (currentTrack != gameClip5)
        {
            previousTrack = gameClip5;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip6()
    {
        if (currentTrack != gameClip6)
        {
            previousTrack = gameClip6;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip7()
    {
        if (currentTrack != gameClip7)
        {
            previousTrack = gameClip7;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip8()
    {
        if (currentTrack != gameClip8)
        {
            previousTrack = gameClip8;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
        }
    }

    public void PlayGameClip9()
    {
        if (currentTrack != gameClip9)
        {
            previousTrack = gameClip9;
            currentTrack = previousTrack;
            ChangeTrack(currentTrack);
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
            previousTrack = gameClip1;
        }
        currentTrack = previousTrack; // set the current track to the previous track
        ChangeTrack(currentTrack); // play our previous track
    }

    public void NextTrack()
    {
        if (currentTrack == gameClip6)
        {
            PlayGameClip1();
        }
        if (currentTrack == gameClip5)
        {
            PlayGameClip6();
        }

        if (currentTrack == gameClip4)
        {
            PlayGameClip5();
        }

        if (currentTrack == gameClip3)
        {
            PlayGameClip4();
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
