using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public CheckPointScore checkPointScore;
    public bool isCurrentTarget; // bool to say if the checkpoint with this script is the current target checkpoint
    Renderer r;
    public bool raceActive = false; // bool to say if a race is currently active (checkpoints have a different colour)
    public bool hitCheckpoint;

    public bool startBlue;
    public bool blueCP1;
    public bool blueCP2;
    public bool blueCP3;
    public bool blueCP4;
    public bool blueCP5;
    public bool blueCP6;
    public bool blueCP7;
    public bool blueCP8;
    public bool blueCP9;
    public bool blueCP10;
    public bool blueCP11;


    void Start()
    {
        if(gameObject.name.Equals("BlueCP1"))
        {
            Debug.Log("Name check for BlueCP1 matched");
            blueCP1 = true;
            if(checkPointScore.checkPoint1C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint1C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP2"))
        {
            blueCP2 = true;
            if (checkPointScore.checkPoint2C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint2C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP3"))
        {
            blueCP3 = true;
            if (checkPointScore.checkPoint3C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint3C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP4"))
        {
            blueCP4 = true;
            if (checkPointScore.checkPoint4C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint4C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP5"))
        {
            blueCP5 = true;
            if (checkPointScore.checkPoint5C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint5C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP6"))
        {
            blueCP6 = true;
            if (checkPointScore.checkPoint6C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint6C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP7"))
        {
            blueCP7 = true;
            if (checkPointScore.checkPoint7C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint7C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP8"))
        {
            blueCP8 = true;
            if (checkPointScore.checkPoint8C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint8C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP9"))
        {
            blueCP9 = true;
            if (checkPointScore.checkPoint9C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint9C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP10"))
        {
            blueCP10 = true;
            if (checkPointScore.checkPoint10C == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.checkPoint10C != true)
            {
                isCurrentTarget = false;
            }
        }
        if (gameObject.name.Equals("BlueCP11"))
        {
            blueCP11 = true;
        }
        if (gameObject.name.Equals("StartBlue"))
        {
            startBlue = true;
            if (checkPointScore.startBlueC == true)
            {
                isCurrentTarget = true;
            }
            if (checkPointScore.startBlueC != true)
            {
                isCurrentTarget = false;
            }
        }
    }

    void Update()
    {
        r = GetComponent<Renderer>();

        if (isCurrentTarget == true)
        {
            r.material.color = Color.cyan;
        }
    }


    void OnTriggerEnter(Collider other) // on a collision between this objects rigidbody and another objects rigidbody
    {
        if(raceActive == false)
        {
            return;
        }
        
        if (other.gameObject.CompareTag("BluePlayer"))
        {
            checkPointScore.IncreaseCheckpointScore();
        }
    }

}
