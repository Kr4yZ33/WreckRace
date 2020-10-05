using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarMGController : MonoBehaviour
{
    public BlueCarAudio blueCarAudio;
    public GameObject mGShotPrefab;
    public float mGShotForce = 100;
    public float mGShotDespawnTime = 5;
    public Transform mGShotSpawnLocation;

    // How fast we can shoot again
    public float ShootDelay = 0.01f;

    private bool _doShoot;
    private float _lastShootTime;

    // Call this to indicate we need to shoot
    public void DoShoot()
    {
        _doShoot = true;
    }

    void Start()
    {
        _doShoot = false;
    }

    void LateUpdate()
    {
        _lastShootTime += Time.deltaTime;
        // Check if we can shoot again using ShootDelay as cooldown
        if (_doShoot && _lastShootTime > ShootDelay)
        {
            _doShoot = false;
            _lastShootTime -= ShootDelay;
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        GameObject clone = Instantiate(mGShotPrefab, mGShotSpawnLocation.position, mGShotSpawnLocation.rotation);
        Destroy(clone, mGShotDespawnTime);
        clone.GetComponent<Rigidbody>().AddForce(mGShotSpawnLocation.forward * mGShotForce);
        blueCarAudio.PlayCarShotClip();
    }
}
