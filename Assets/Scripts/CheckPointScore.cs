using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScore : MonoBehaviour
{
    public CheckPointController checkPointController; // the object with the name StartBlue should be assigned to this reference in the editor

    public bool raceActiveC;
    bool canReset;
    
    public bool startBlueC;
    public bool checkPoint1C;
    public bool checkPoint2C;
    public bool checkPoint3C;
    public bool checkPoint4C;
    public bool checkPoint5C;
    public bool checkPoint6C;
    public bool checkPoint7C;
    public bool checkPoint8C;
    public bool checkPoint9C;
    public bool checkPoint10C;
    public bool checkPoint11C;

    public float timeToZero;
    public float currentTime;

    public int cpScoreTotal;
    public int scoreMultiplier = 100;
    public float resetRaceTimeDelay = 15f;


    private void Start()
    {
        if(canReset == true)
        {
            canReset = false;
            startBlueC = false;
            checkPoint1C = false;
            checkPoint2C = false;
            checkPoint3C = false;
            checkPoint4C = false;
            checkPoint5C = false;
            checkPoint6C = false;
            checkPoint7C = false;
            checkPoint8C = false;
            checkPoint9C = false;
            checkPoint10C = false;
        }
        
        if(raceActiveC == true && startBlueC == true && checkPointController.startBlue == true)
        {
            // send message to player race has started
            TallyCPScore();
        }

        if (timeToZero == 0)
        {
            OutOfTime();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(checkPoint10C == true)
        {
            // call function to end race and tally final score, send message of congratulations to player.
            raceActiveC = false;
        }

        // currentTime = time + delta time
    }

    public void IncreaseCheckpointScore()
    {
        if(checkPointController.startBlue == true)
        {
            if(startBlueC == true)
            {
                return;
            }

            if(startBlueC == false)
            {
                raceActiveC = true;
                checkPoint1C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint1C == false)
            {
                checkPoint2C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint2C == false)
            {
                checkPoint3C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint3C == false)
            {
                checkPoint4C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint4C == false)
            {
                checkPoint5C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint5C == false)
            {
                checkPoint6C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint6C == false)
            {
                checkPoint7C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint7C == false)
            {
                checkPoint8C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint8C == false)
            {
                checkPoint9C = true;
                timeToZero = 30; // reset the time to zero to 30 seconds
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }

            if (checkPoint9C == false)
            {
                checkPoint10C = true;
                // add score multiplier to remaining time, then add that to the Score Total controller script
            }
        }

        // on last checkpoint reset all bools to false
    }

    /// <summary>
    /// 
    /// </summary>
    void TallyCPScore()
    {
        // cpScoreTotal = number of checkpoints passed * score modifier (later I want to add extra score for time to zero time that is left over)
    }

    /// <summary>
    /// 
    /// </summary>
    void OutOfTime()
    {
        
        {
            // finish racing game and give player a message
            _ = EndDelay();
        }
    }

    /// <summary>
    /// Our delay between race over and checkpoint reset
    /// </summary>
    /// <returns></returns>
    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(resetRaceTimeDelay); // Amount of time we wait
        canReset = true; // set the can Reset bool to True
    }
}
