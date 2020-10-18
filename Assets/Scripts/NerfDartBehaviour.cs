using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aligns self to velocity, if speed is above a small tolerance. Purely visual niceity.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class NerfDartBehaviour : MonoBehaviour
{
    protected new Rigidbody r;

    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        //align to direction of travel if we are moving fast enough, small tolerance prevents jitter due to forcing a rotation on
        // an object with colliders that will then have new overlaps and be physic'ed apart
        if(r.velocity.sqrMagnitude > 0.5f)
            transform.rotation = Quaternion.LookRotation(r.velocity.normalized, Vector3.up);
    }
}
