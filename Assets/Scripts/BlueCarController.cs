using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarController : MonoBehaviour
{
    public BlueCarAudio carAudio; // reference to the Car Audio script
    //public AnimationHandler animationHandler; // reference to the Animation Handler script
    public XRInputs xRInputManager; // reference to the XR Inputs script
    public List<WheelCollider> throttleWheels; // list of wheel colliders used for throttle
    public List<WheelCollider> steeringWheels; // list of wheel colliders used for steering
    public float strengthCoefficient = 200000f; // strength coefficient
    public float maxTurn = 10f; // turning angle
    public Transform blueRaceStart; // transform of the right race start position
    //public Transform leftRaceStart; // transform of the left race start position
    //public Transform topRightPortal; // transform of the top right portal
    public Rigidbody rb; // reference to the Rigidbody of the object this script is attached to

    public float m_Accelleration; // the acceleration value
    public float m_Steering; // the steering value
    public float wheelDampening; // the wheel dampening (how far you can coast before friction slows you down)

    public enum DrivingStates { Idle, Ignition, Accelerate, Brake } // our different driving states
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
        //currentDrivingState = DrivingStates.Idle;
        xRInputManager = GetComponent<XRInputs>();
        rb = GetComponent<Rigidbody>(); // get the Rigidbody of the object this script is attched to
    }

    private void Update()
    {
        if (xRInputManager.idle == true) // if the bool for idle from the XR Inputs scrip is equal to true
        {
            currentDrivingState = DrivingStates.Idle; // set the current driving state to equal the Driving State Idle
            HandleIdleState(); // call our idle state function
        }
        if (xRInputManager.accelerate == true && xRInputManager.brake != true) // if the bool for accelerate from the XR Inputs scrip is equal to true and the bool for brake is not equal to true
        {
            currentDrivingState = DrivingStates.Accelerate; // set the current driving state to equal the Driving State Accelerate
            HandleAccelrateState(); // call our accelerate state function
        }
        if (xRInputManager.brake == true) // if the bool for brake from the XR Inputs scrip is equal to true
        {
            currentDrivingState = DrivingStates.Brake; // set the current driving state to equal the Driving State Brake
            HandleBrakeState(); // call our brake state function
        }
        if (xRInputManager.turnL == true) // if the turnL for brake from the XR Inputs scrip is equal to true
        {
            HandleTurnLState(); // call our turnL state function
        }
        if (xRInputManager.turnR == true)  // if the bool for turnR from the XR Inputs scrip is equal to true
        {
            HandleTurnRState(); // call our turnR state function
        }
        if (xRInputManager.turnL == false && xRInputManager.turnR == false)  // if the bool for turnL from the XR Inputs scrip is equal to false and if the bool for turnR from the XR Inputs scrip is equal to false (we are not turning)
        {
            m_Steering = 0f; // set steering to zero
        }
    }

    /// <summary>
    /// function that handles our Idle state
    /// </summary>
    private void HandleIdleState()
    {
        if (currentDrivingState == DrivingStates.Idle) // if the current driving state is equal to the Driving State Idle
        {
            carAudio.PlayIdleClip(); // play the Idle clip from the Car Audio script
            m_Accelleration = 0f; // set the acceleration value to 0f
            m_Steering = 0f; // set the steering value to 0f
            wheelDampening = 500f;
        }
        //if (animationHandler.CurrentState != AnimationHandler.AnimationState.Idle) // if the current state of the animation handler is not eqaul to Idle
        //{
            //animationHandler.CurrentState = AnimationHandler.AnimationState.Idle;  // set the animation handler current state to Idle
        //}
    }

    /// <summary>
    /// function that handles our Accelerate state
    /// </summary>
    private void HandleAccelrateState()
    {
        if (currentDrivingState == DrivingStates.Accelerate) // if the current driving state is equal to the Driving State Accelerate
        {
            carAudio.PlayAccelerateClip();  // play the Accelerate clip from the Car Audio script
            m_Accelleration = 5f; // set the acceleration value to 5f
            wheelDampening = 250f;
        }
        //if (animationHandler.CurrentState != AnimationHandler.AnimationState.Accelerate) // if the current state of the animation handler is not eqaul to Accelerate
        //{
            //animationHandler.CurrentState = AnimationHandler.AnimationState.Accelerate;  // set the animation handler current state to Accelerate
        //}
    }

    /// <summary>
    /// function that handles our Brake state
    /// </summary>
    private void HandleBrakeState()
    {
        if (currentDrivingState == DrivingStates.Brake) // if the current driving state is equal to the Driving State Brake
        {
            carAudio.PlayBrakeClip();  // play the Brake clip from the Car Audio script
            m_Accelleration = -5f; // set the acceleration value to -5f
            wheelDampening = 10000f;
        }
        //if (animationHandler.CurrentState != AnimationHandler.AnimationState.Brake) // if the current state of the animation handler is not eqaul to Brake
        //{
            //animationHandler.CurrentState = AnimationHandler.AnimationState.Brake;  // set the animation handler current state to Brake
        //}
    }

    /// <summary>
    /// function that handles our TurnR state
    /// </summary>
    private void HandleTurnRState() // if the current driving state is equal to the Driving State TurnR
    {
        {
            m_Steering = 1f; // set the steering value to 1f
        }
        //if (animationHandler.CurrentState != AnimationHandler.AnimationState.TurningR) // if the current state of the animation handler is not eqaul to TurningR
        //{
           //animationHandler.CurrentState = AnimationHandler.AnimationState.TurningR; // set the animation handler current state to TurningR
        //}
    }

    /// <summary>
    /// function that handles our TurnL state
    /// </summary>
    private void HandleTurnLState() // if the current driving state is equal to the Driving State TurnL
    {
        {
            m_Steering = -1f; // set the steering value to -1f
        }
        //if (animationHandler.CurrentState != AnimationHandler.AnimationState.TurningL) // if the current state of the animation handler is not eqaul to TurningL
        //{
            //animationHandler.CurrentState = AnimationHandler.AnimationState.TurningL; // set the animation handler current state to TurningL
        //}
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


    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("BlueRaceStart")) // if a collider with the tag RightRaceStart interacts with our collider
        {
            rb.velocity = Vector3.zero; // set the rigidbody velocity to zero
            rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
            transform.position = blueRaceStart.position; // set the transform position of the object this script is attached to to the right race start position transform
            transform.rotation = blueRaceStart.rotation; // set the transform rotation of the object this script is attached to to the right race start transform's rotation
            xRInputManager.LockToCarFloorBlue();
        }
        //if (trigger.CompareTag("RedRaceStart")) // if a collider with the tag LeftRaceStart interacts with our collider
        //{
            //rb.velocity = Vector3.zero;  // set the rigidbody velocity to zero
            //rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
            //transform.position = redRaceStart.position; // set the transform position of the object this script is attached to to the left race start position transform
            //transform.rotation = redRaceStart.rotation; // set the transform rotation of the object this script is attached to to the left race start transform's rotation
            //xRInputManager.LockToCarFloorRed();
        //}
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
}
