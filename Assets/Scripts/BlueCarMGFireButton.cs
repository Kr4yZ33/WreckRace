using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarMGFireButton : MonoBehaviour
{
    public BlueCarMGController blueCarMGController;
    public BlueCarMGControllerL blueCarMGControllerL;

    private void OnTriggerEnter(Collider other) // on a collision between this objects rigidbody and another objects rigidbody
    {
        if(other.gameObject.CompareTag("BluePlayer"))
        {
            blueCarMGController.Fire();
            blueCarMGControllerL.Fire();
        }
    }

    private void OnTriggerExit(Collider other) // on a collision exit between this objects rigidbody and another objects rigidbody
    {
        if (other.gameObject.CompareTag("BluePlayer"))
        {
            blueCarMGController.Fire();
            blueCarMGControllerL.Fire();
        }
    }
}
