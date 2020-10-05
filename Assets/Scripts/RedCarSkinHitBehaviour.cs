using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarSkinHitBehaviour : MonoBehaviour
{
    public RedCarSkinExplosion carSkinExplosion;
    public RedCarAudio redCarAudio;

    public bool hit1; // reference to our true or false value for hit1
    public bool hit2; // reference to our true or false value for hit2
    public bool hit3; // reference to our true or false value for hit3
    public bool hit4; // reference to our true or false value for hit4
    public bool hit5; // reference to our true or false value for hit5
    public bool hit6; // reference to our true or false value for hit6

    //public AudioClip skeletonHitSoundClip; // reference to our idle clip
    //public float volume = 0.5f; // Reference to the volume of our scare shot clip (plays over game musice that is already playing)
    //public AudioSource audioSource; // reference to our audiosource

    Rigidbody blockRigid; // reference to the rigid body of the object this script is assigned to
    Renderer r; // refernce to our renderer

    // Start is called before the first frame update
    void Start()
    {
        blockRigid = GetComponent<Rigidbody>(); // Get the rigid body of the object this script is assigned to
        r = GetComponent<Renderer>(); // Get the renderer of the object this script is assigned to
    }

    void Update()
    {
        ApplyHitColour(); // call the ApplyHitColour function
        CheckHitStatus(); // call the CheckHitStstus function
    }

    /// <summary>
    /// Applies colour to the object this script is assigned to based on which hit bool is set to true
    /// </summary>
    void ApplyHitColour()
    {
        if (hit1 == true && hit2 == false) // if hit1 is true but hit 2 is not true yet
        {
            r.material.color = Color.yellow; // apply the yellow colour to the object
        }
        if (hit2 == true && hit3 == false) // if hit2 is true but hit 3 is not true yet
        {
            r.material.color = Color.yellow; // apply the yellow colour to the object
        }
        if (hit3 == true && hit4 == false) // if hit3 is true but hit 4 is not true yet
        {
            r.material.color = Color.black; // apply the grey colour to the object
        }
        if (hit4 == true && hit5 == false) // if hit4 is true but hit 5 is not true yet
        {
            r.material.color = Color.black; // apply the Grey colour to the object
        }
        if (hit5 == true && hit6 == false) // if hit5 is true but hit 6 is not true yet
        {
            r.material.color = Color.magenta; // apply the black colour to the object
        }
        if (hit6 == true) // if hit6 is true
        {
            r.material.color = Color.magenta; // apply the black colour to the object
        }
    }

    /// <summary>
    /// Function that checks to see if hit3 is true yet or not
    /// </summary>
    void CheckHitStatus()
    {
        if (hit6 == true) // if hit6 is true
        {
            blockRigid.useGravity = true; // enable gravity on the object this script is assigned to
            carSkinExplosion.ExplodeCarSkin(); // call the Skeleton explosion function from the Explode script
            redCarAudio.PlayCarSkinExplode();
        }
    }

    /// <summary>
    /// handles what happens when an object collides with the rigid body this script is assigned to
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other) // on a collision between this objects rigidbody and another objects rigidbody
    {
        Debug.Log("I Have collided with" + other.gameObject.name); // debug that outputs what happened with the collision
        if (other.gameObject.layer == 11)
        {
            Destroy(other.gameObject); // if the thing hitting us operates on the red ranged layer, destroy it
        }
        if (other.gameObject.layer != 10 && other.gameObject.layer != 11) // if the layer of the object colliding with us is not red ranged or melee
        {
            // There is no hit register for light weapons as car skin is immune to light weapons
            //audioSource.PlayOneShot(skeletonHitSoundClip); // play our hit sound soundclip
            if (other.gameObject.CompareTag("MediumWeapon")) // If the thing colliding with us has the tag Medium Weapon
            {
                if (hit5 == true && hit6 == false) // otherwise if hit3 is true but hit4 is false
                {
                    hit6 = true; // and also set hit6 to true
                }
                if (hit4 == true && hit5 == false) // otherwise if hit3 is true but hit4 is false
                {
                    hit5 = true; // set hit5 to true
                    hit6 = true; // and also set hit6 to true
                }
                if (hit3 == true && hit4 == false) // otherwise if hit3 is true but hit4 is false
                {
                    hit4 = true; // set hit4 to true
                    hit5 = true; // and also set hit5 to true
                }
                if (hit2 == true && hit3 == false) // otherwise if only hit3 is false
                {
                    hit3 = true; // set hit3 to true
                    hit4 = true; // set hit4 to true
                }
                if (hit1 == true && hit2 == false) // otherwise if hit1 is true but the other hit bools are false
                {
                    hit2 = true; // set hit2 to true
                    hit3 = true; // and also set hit3 to true
                }
                if (hit1 == false) // if none of the hit bools are true
                {
                    hit1 = true; // set hit1 to true
                    hit2 = true; // and also set hit2 to true
                }
            }
            else if (other.gameObject.CompareTag("HeavyWeapon")) // If the thing colliding with us has the tag Heavy Weapon
            {
                if (hit5 == true && hit6 == false) // otherwise if only hit6 is false
                {
                    hit6 = true; // also set hit6 to true
                }
                if (hit4 == true && hit5 == false) // otherwise if only hit6 is false
                {
                    hit5 = true; // also set hit5 to true
                    hit6 = true; // also set hit6 to true
                }
                if (hit3 == true && hit4 == false) // otherwise if hit 4 is true but hit 5 is false
                {
                    hit4 = true; // also set hit4 to true
                    hit5 = true; // also set hit5 to true
                    hit6 = true; // and also set hit6 to true
                }
                if (hit2 == true && hit3 == false) // otherwise if hit 3 is true and hit 4 is false
                {
                    hit3 = true; // also set hit4 to true
                    hit4 = true; // also set hit5 to true
                    hit5 = true; // and also set hit6 to true
                }
                if (hit1 == true && hit2 == false) // otherwise if hit 2 is true and hit 3 is false
                {
                    hit2 = true; // also set hit2 to true
                    hit3 = true; // and also set hit3 to true
                    hit4 = true; // also set hit4 to true
                }
                if (hit1 == false) // if none of the hit bools are true
                {
                    hit1 = true; // set hit1 to true
                    hit2 = true; // also set hit2 to true
                    hit3 = true; // and also set hit3 to true
                }
            }
            if (other.gameObject.layer == 9)
            {
                Destroy(other.gameObject); // if the thing hitting us operates on the blue ranged layer, destroy it
            }
        }
    }
}
