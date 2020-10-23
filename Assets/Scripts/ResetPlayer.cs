using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    Rigidbody rb; // reference to the Rigidbody of the object this script is attached to
    public Transform bluePlayerResetTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetBluePlayer()
    {
        rb.velocity = Vector3.zero;  // set the rigidbody velocity to zero
        rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
        transform.position = bluePlayerResetTransform.position; // set the transform position of the object this script is attached to to the blue car start position transform
        transform.rotation = bluePlayerResetTransform.rotation; // set the transform rotation of the object this script is attached to to the blue car start transform's rotation
    }
}
