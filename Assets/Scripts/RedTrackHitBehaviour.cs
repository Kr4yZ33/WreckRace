using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrackHitBehaviour : MonoBehaviour
{
    public BlockScore blockScore; // reference to the Block Score script
    public int score = 1; // int or number that can be set in the editor to adjust how much points you get when this object explodes

    public RedTrackExplosion trackExplosion; // reference to the Armour Explosion script
    bool hit1; // reference to our true or false value for hit1
    bool hit2; // reference to our true or false value for hit2
    bool hit3; // reference to our true or false value for hit3
    bool hit4; // reference to our true or false value for hit4
    bool hit5; // reference to our true or false value for hit5
    bool hit6; // reference to our true or false value for hit6
    bool hit7; // reference to our true or false value for hit6
    bool hit8; // reference to our true or false value for hit6
    bool hit9; // reference to our true or false value for hit6
    bool hit10; // reference to our true or false value for hit6

    //Rigidbody blockRigid; // reference to the rigid body of the object this script is assigned to
    Renderer r; // refernce to our renderer

    // Start is called before the first frame update
    void Start()
    {
        //blockRigid = GetComponent<Rigidbody>(); // Get the rigid body of the object this script is assigned to
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
            r.material.color = Color.white; // apply the black colour to the object
        }
        if (hit2 == true && hit3 == false) // if hit2 is true but hit 3 is not true yet
        {
            r.material.color = Color.white; // apply the black colour to the object
        }
        if (hit3 == true && hit4 == false) // if hit3 is true but hit 4 is not true yet
        {
            r.material.color = Color.black; // apply the black colour to the object
        }
        if (hit4 == true && hit5 == false) // if hit4 is true but hit 5 is not true yet
        {
            r.material.color = Color.black; // apply the black colour to the object
        }
        if (hit5 == true && hit6 == false) // if hit5 is true but hit 6 is not true yet
        {
            r.material.color = Color.grey; // apply the grey colour to the object
        }
        if (hit6 == true && hit7 == false) // if hit6 is true but hit 7 is not yet true
        {
            r.material.color = Color.grey; // apply the grey colour to the object
        }
        if (hit7 == true && hit8 == false) // if hit7 is true but hit 8 is not true yet
        {
            r.material.color = Color.grey; // apply the grey colour to the object
        }
        if (hit9 == true && hit10 == false) // if hit9 is true but hit 10 is not true yet
        {
            r.material.color = Color.black; // apply the white colour to the object
        }
        if (hit10 == true) // if hit 10 is true
        {
            r.material.color = Color.black; // apply the white colour to the object
        }
    }

    /// <summary>
    /// Function that checks to see if hit10 is true yet or not
    /// </summary>
    void CheckHitStatus()
    {
        if (hit10 == true) // if hit10 is true
        {
            //blockRigid.useGravity = true; // enable gravity on the object this script is assigned to
            trackExplosion.ExplodeTrack(); // call the Skeleton explosion function from the Explode script
            AddBlockScore(); // call the add block score function
        }
    }

    /// <summary>
    /// handles what happens when an object collides with the rigid body this script is assigned to
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other) // on a collision between this objects rigidbody and another objects rigidbody
    {
        // Debug.Log("I Have collided with" + other.gameObject.name); // debug that outputs what happened with the collision
        {
            if (other.gameObject.layer == 11)
            {
                Destroy(other.gameObject); // if the thing hitting us operates on the redranged layer, destroy it
            }
            if (other.gameObject.layer != 9) // if the layer of the object colliding with us is not blue ranged
            {
                return;
            }
            if (other.gameObject.CompareTag("MediumWeapon"))// If the thing colliding with us has the tag Medium Weapon (because this is track, make the hit behave like a light hit normally would x1 hits)
            {
                if (hit9 == true && hit10 == false) // If hit9 is true but hit10 is not true
                {
                    hit10 = true; // set hit10 to true
                }
                if (hit8 == true && hit9 == false) // If hit8 is true but hit9 is not true
                {
                    hit9 = true; // set hit9 to true
                }
                if (hit7 == true && hit8 == false) // If hit7 is true but hit8 is not true
                {
                    hit8 = true; // set hit7 to true
                }
                if (hit6 == true && hit7 == false) // If hit6 is true but hit7 is not true
                {
                    hit7 = true; // set hit7 to true
                }
                if (hit5 == true && hit6 == false) // If hit5 is true but hit6 is not true
                {
                    hit6 = true; // set hit6 to true
                }
                if (hit4 == true && hit5 == false) // otherwise if hit4 is true and hit5 is false
                {
                    hit5 = true; // set hit5 to true
                }
                if (hit3 == true && hit4 == false) // If hit2 is true but hit3 is not true
                {
                    hit4 = true; // set hit4 to true
                }
                if (hit2 == true && hit3 == false) // otherwise if hit1 is true and hit two is false
                {
                    hit3 = true; // set hit2 to true
                }
                if (hit1 == true && hit2 == false) // otherwise if hit1 is true and hit two is false
                {
                    hit2 = true; // set hit2 to true
                }
                if (hit1 == false) // If hit1 is false
                {
                    hit1 = true; // set hit1 to true
                }
            }
            if (other.gameObject.CompareTag("HeavyWeapon")) // If the thing colliding with us has the tag Heavy Weapon (because this is track, make the hit behave like a med hit normally would x2 hits)
            {
                if (hit9 == true && hit10 == false) // otherwise if hit9 is true but hit10 is false
                {
                    hit10 = true; // set hit10 to true
                }
                if (hit8 == true && hit9 == false) // otherwise if hit9 is true but hit10 is false
                {
                    hit9 = true;
                    hit10 = true; // set hit10 to true
                }
                if (hit7 == true && hit8 == false) // otherwise if hit8 is true but hit9 is false
                {
                    hit8 = true; // set hit9 to true
                    hit9 = true; // and also set hit10 to true
                }
                if (hit6 == true && hit7 == false) // otherwise if hit7 is true but hit8 is false
                {
                    hit7 = true; // set hit8 to true
                    hit8 = true; // and also set hit9 to true
                }
                if (hit5 == true && hit6 == false) // otherwise if hit3 is true but hit4 is false
                {
                    hit6 = true; // and also set hit6 to true
                    hit7 = true;
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
                if (other.gameObject.layer == 9)
                {
                    Destroy(other.gameObject); // if the thing hitting us operates on the blue ranged layer, destroy it
                }
            }
        }
    }

    void AddBlockScore()
    {
        blockScore.GetComponent<BlockScore>().AddScore(score); //call this function when you want to add score
        Debug.Log("BlockScoreHit"); // debug to log "block score hit" when this function is called
    }
}
