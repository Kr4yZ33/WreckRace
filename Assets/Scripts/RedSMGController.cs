using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSMGController : MonoBehaviour
{
    public AudioSource audioSource; // refernce to the Audio Manager script
    public AudioClip redSMGShotClip;
    public GameObject redSMGShotPrefab;
    public float redSMGShotForce = 1000;
    public float redSMGShotDespawnTime = 5;
    public Transform redSMGShotSpawnLocation;
    public float volume = 1;

    public bool canShoot = true; // True or false statement regarding if we can shoot yet or not (following the shot delay)
    public float timeBetweenShots = 0.1f; // 0.01 second between each shot

    public void Fire()
    {
        if (canShoot == false)
        {
            return;
        }
        else
        {
            GameObject clone = Instantiate(redSMGShotPrefab, redSMGShotSpawnLocation.position, redSMGShotSpawnLocation.rotation);
            Destroy(clone, redSMGShotDespawnTime);
            clone.GetComponent<Rigidbody>().AddForce(redSMGShotSpawnLocation.forward * redSMGShotForce);
            audioSource.PlayOneShot(redSMGShotClip, volume); // call the function to play our canns shot sound from the Audio Manager script
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
