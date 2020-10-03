using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public AudioSource audioSource; // refernce to the Audio Manager script
    public AudioClip cannonShotClip;
    public GameObject cannonShotPrefab;
    public float cannonShotForce = 1000;
    public float cannonShotDespawnTime = 5;
    public Transform cannonShotSpawnLocation;
    public float volume = 5;


    public void Fire()
    {
        GameObject clone = Instantiate(cannonShotPrefab, cannonShotSpawnLocation.position, cannonShotSpawnLocation.rotation);
        Destroy(clone, cannonShotDespawnTime);
        clone.GetComponent<Rigidbody>().AddForce(cannonShotSpawnLocation.forward * cannonShotForce);
        audioSource.PlayOneShot(cannonShotClip, volume); // call the function to play our canns shot sound from the Audio Manager script
    }
}