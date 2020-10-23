using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMGHand : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shotClip;
    public GameObject mGShotPrefab;
    public float mGShotForce = 1800;
    public float mGShotDespawnTime = 5;
    public Transform mGShotSpawnLocation;

    public bool canShoot = true; // True or false statement regarding if we can shoot yet or not (following the shot delay)
    public float timeBetweenShots = 0.01f; // 0.01 second between each shot

    public float volume = 0.3f;

    public void Fire()
    {
        if (canShoot == false)
        {
            return;
        }
        else
        {
            GameObject clone = Instantiate(mGShotPrefab, mGShotSpawnLocation.position, mGShotSpawnLocation.rotation);
            Destroy(clone, mGShotDespawnTime);
            clone.GetComponent<Rigidbody>().AddForce(mGShotSpawnLocation.forward * mGShotForce);
            audioSource.PlayOneShot(shotClip, volume);
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
