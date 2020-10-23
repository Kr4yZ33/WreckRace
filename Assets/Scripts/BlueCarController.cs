using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarController : MonoBehaviour
{
    //public AnimationHandler animationHandler; // reference to the Animation Handler script
    public GameManager gameManager; // reference to the Gamemanager script
    public List<WheelCollider> throttleWheels; // list of wheel colliders used for throttle
    public List<WheelCollider> steeringWheels; // list of wheel colliders used for steering
    public float strengthCoefficient = 200000f; // strength coefficient
    public float maxTurn = 10f; // turning angle

    public Transform blueCarStartPosition; // refernec to the transform for the blue car starting position (used for resetting the car)
    public Transform blueRaceStart; // transform of the right race start position
    public Transform redRaceStart; // transform of the left race start position
    public Rigidbody rb; // reference to the Rigidbody of the object this script is attached to

    public float m_Accelleration; // the acceleration value
    public float m_Steering; // the steering value
    public float wheelDampening; // the wheel dampening (how far you can coast before friction slows you down)

    public enum DrivingStates { Idle, Accelerate, Brake } // our different driving states
    public DrivingStates currentDrivingState; // the current driving state our car is in
    
    // Idle state variables
    //m_Accelleration = 0f;
    //m_Steering = 0f;
    //wheelDampening = 500f;

    // Ignition state variables
    // if using car is true and car first enter is true

    // Accelerate state variables
    //m_Accelleration = 5f;
    //wheelDampening = 250f;

    // Brake state variable 
    //m_Accelleration = -5f;
    //wheelDampening = 10000f;

    // TurningR state variables
    //m_Steering = 1f;

    // TurningL state variables
    //m_Steering = -1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the Rigidbody of the object this script is attched to
    }

    private void Update()
    {
        if (gameManager.turnL == false && gameManager.turnR == false)
        {
            m_Steering = 0f; // set the steering value to 0f
        }

        if (gameManager.turnR == true)
        {
            m_Steering = 1f; // set the steering value to 1f
        }

        if (gameManager.turnL == true)
        {
            m_Steering = -1f; // set the steering value to -1f
        }
    }

    /// <summary>
    /// function that handles our Idle state
    /// </summary>
    public void HandleIdleState()
    {
        if(gameManager.usingCarBlue == false)
        {
            return;
        }
        
        if (currentDrivingState == DrivingStates.Idle) // if the current driving state is equal to the Driving State Idle
        {
            return;
        }
        if (currentDrivingState != DrivingStates.Idle)
        {
            currentDrivingState = DrivingStates.Idle;
            m_Accelleration = 0f; // set the acceleration value to 0f
            m_Steering = 0f; // set the steering value to 0f
            wheelDampening = 500f;
        }
    }

    /// <summary>
    /// function that handles our Accelerate state
    /// </summary>
    public void HandleAccelrateState()
    {
        if (currentDrivingState == DrivingStates.Accelerate)
        {
            return;
        }
        if (currentDrivingState != DrivingStates.Accelerate)
        {
            currentDrivingState = DrivingStates.Accelerate; // set the current driving state to equal the Driving State Accelerate
            m_Accelleration = 5f; // set the acceleration value to 5f
            wheelDampening = 250f;
        }
    }

    /// <summary>
    /// function that handles our Brake state
    /// </summary>
    public void HandleBrakeState()
    {
        if (currentDrivingState == DrivingStates.Brake)
        {
            return;
        }
        if (currentDrivingState != DrivingStates.Brake)
        {
            currentDrivingState = DrivingStates.Brake; // set the current driving state to equal the Driving State Brake
            m_Accelleration = -5f; // set the acceleration value to -5f
            wheelDampening = 10000f;
        }
    }

    /// <summary>
    /// get the value for the acceleration float
    /// </summary>
    public float Accelleration
    {
        get { return m_Accelleration; }
    }

    /// <summary>
    /// get the value for the steering float
    /// </summary>
    public float Steering
    {
        get { return m_Steering; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheels) // for each wheel collider in the throttle wheels list
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * Accelleration; // set the wheel motor torque to the set strength coeffecient and multiply it by time and acceleration
            wheel.wheelDampingRate = wheelDampening; // set the wheel dampining rate to equal the set wheel dampening value
        }

        foreach (WheelCollider wheel in steeringWheels) // for each wheel collider is the steering wheels list
        {
            wheel.steerAngle = maxTurn * Steering; // set the wheel steering angle to be the maxturn muliplied by the set steering value
            wheel.wheelDampingRate = wheelDampening; // set the wheel dampening rate to be the set wheel dampening value
        }
    }

    /// <summary>
    /// set trigger condition for collisions with the object this script is attached to
    /// </summary>
    /// <param name="trigger"></param>
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("BluePlayer")) // if the trigger colliding with us has the tag blue Player
        {
            gameManager.usingCarBlue = true; // set bool for using car to true
        }
        //if (trigger.CompareTag("RedPlayer")) // if the trigger colliding with us has the tag Player
        //{
        // usingCarRed = true; // set bool for using car to true
        //}


        if (trigger.CompareTag("BlueRaceStart")) // if a collider with the tag RightRaceStart interacts with our collider
        {
            ResetCarToBlueRaceStart();
        }
        if (trigger.CompareTag("RedRaceStart")) // if a collider with the tag LeftRaceStart interacts with our collider
        {
            rb.velocity = Vector3.zero;  // set the rigidbody velocity to zero
            rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
            transform.position = redRaceStart.position; // set the transform position of the object this script is attached to to the left race start position transform
            transform.rotation = redRaceStart.rotation; // set the transform rotation of the object this script is attached to to the left race start transform's rotation
            gameManager.LockToCarFloorBlue();
        }
    }

    public void ResetBlueCar()
    {
        rb.velocity = Vector3.zero;  // set the rigidbody velocity to zero
        rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
        transform.position = blueCarStartPosition.position; // set the transform position of the object this script is attached to to the blue car start position transform
        transform.rotation = blueCarStartPosition.rotation; // set the transform rotation of the object this script is attached to to the blue car start transform's rotation
    }

    //void OnTriggerExit(Collider trigger)
    //{
    // disable the piece of code for mounting when we exit that trigger
    //if (trigger.CompareTag("BluePlayer"))
    //{
    //gameManager.usingCarBlue = false; // disable the using car bool
    //}
    // disable the piece of code for mounting when we exit that trigger
    //if (trigger.CompareTag("RedPlayer"))
    //{
    //usingCarRed = false; // disable the using car bool
    //}
    //}

    public void ResetCarToBlueRaceStart()
    {
        rb.velocity = Vector3.zero; // set the rigidbody velocity to zero
        rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
        transform.position = blueRaceStart.position; // set the transform position of the object this script is attached to to the right race start position transform
        transform.rotation = blueRaceStart.rotation; // set the transform rotation of the object this script is attached to to the right race start transform's rotation
        gameManager.LockToCarFloorBlue();
    }

    //public void ExitBlueCar()
    //{
        //xRRigBlue.position = bluesCarExit.position; // set the XR rig position from the XR Rig script to the position of the car floor
        //xRRigBlue.rotation = bluesCarExit.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car floor
    //}
}
