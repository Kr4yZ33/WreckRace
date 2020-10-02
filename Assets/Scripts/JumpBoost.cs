using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    Rigidbody r;

    public float boostAmount =1000f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueMelee"))
        {
            r = other.GetComponent<Rigidbody>();       
            {
                r.AddForce(transform.forward * boostAmount);
                r.AddForce(transform.up * boostAmount);
            }
            Debug.Log("BOOST!");
        } 
    }

    //void OnTriggerExit(Collider other)
    //{
        //if (other.gameObject.CompareTag(("BlueMelee")))
        //{
            //r.AddForce(transform.forward / boostAmount);
            //Debug.Log("normal");
        //}  
    //}
}
