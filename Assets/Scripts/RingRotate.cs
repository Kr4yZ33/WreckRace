using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotate : MonoBehaviour
{
    public GameObject ringToRotate; // a refernce to the ring we want to rotate

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(ringToRotate.transform.position, Vector3.up, -20 * Time.deltaTime); // Make the object rotate at 20 degrees per second
    }
}
