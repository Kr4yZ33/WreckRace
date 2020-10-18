using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarCannonController : MonoBehaviour
{
    public AudioSource audioSource; // refernce to the Audio Manager script
    public AudioClip redCarCannonShotClip;
    public GameObject redCarCannonShotPrefab;
    public float redCarCannonShotForce = 1000;
    public float redCarCannonShotDespawnTime = 5;
    public Transform redCarCannonShotSpawnLocation;
    public float volume = 5;

    public bool canShoot = true; // True or false statement regarding if we can shoot yet or not (following the shot delay)
    public float timeBetweenShots = 0.5f; // 0.05 second between each shot

    void Update()
    {
        if (canShoot == false)
        {
            return;
        }
        else
        {
            Fire();
        }
            
    }

    public void Fire()
    {
        {
            GameObject clone = Instantiate(redCarCannonShotPrefab, redCarCannonShotSpawnLocation.position, redCarCannonShotSpawnLocation.rotation);
            Destroy(clone, redCarCannonShotDespawnTime);
            clone.GetComponent<Rigidbody>().AddForce(redCarCannonShotSpawnLocation.forward * redCarCannonShotForce);
            audioSource.PlayOneShot(redCarCannonShotClip, volume); // call the function to play our canns shot sound from the Audio Manager script
            canShoot = false;
            StartCoroutine(ShootDelay()); // start the shoot delay coroutine
        }
    }

    /// <summary>
    /// Our delay between shots
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(timeBetweenShots); // Amount of time we wait
        canShoot = true; // set the can Shoot bool to True
    }
}
