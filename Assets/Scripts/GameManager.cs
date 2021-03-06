﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    XRNode xRNodeB = XRNode.LeftHand; // reference to the XR node (left hand)
    //readonly XRNode xRNodeR = XRNode.RightHand;
    readonly List<InputDevice> devices = new List<InputDevice>(); // read only list of input devices

    InputDevice deviceB; // reference to our input device
    //public RedCarController redCarController;
    public BlueCarController blueCarController;
    public ResetPlayer resetPlayer;

    public bool usingCarBlue = false; // bool for using the blue car being true or not
    public bool usingCarRed = false; // bool for using the red car being true or not
    public bool accelerate; // bool for the car accelerating being true or not
    public bool idle; // bool for if the car being idle is true or not
    public bool brake; // bool for if the car braking is true or not
    public bool turnR; // bool for if the car turning right is true or not
    public bool turnL; // bool for if the car turning left is true or not

    public Transform blueCarFloor; // reference to the transform fo rthe car floor
    public Transform blueCarRoof; // reference to trhe roof of the blue car
    //public Transform redCarFloor;
    public Transform xRRigBlue; // reference to the blue players XR rig
    //public Transform xRRigRed; // reference to the red players XR rig

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNodeB, devices); // get any input devices connected
        deviceB = devices.FirstOrDefault(); // set our device to the first or default in the input device list
    }

    void OnEnable()
    {
        if (!deviceB.isValid) // if not equal to device is valid (there is no device)
        {
            GetDevice(); // call the get device function
        }
    }

    void Update()
    {
        FunctionUpdate();

        if (usingCarBlue == true) // if using the car bool is true
        {
            LockToCarFloorBlue(); // call the lock to car floor function
            ControlsWhileDrivingB(); // call the function for controls while driving left controller
            ControlsWhileDrivingR(); // call the function for controls while driving right controller
        }

        if (usingCarRed == true) // if using the car bool is true
        {
            //LockToCarFloorRed(); // call the lock to car floor function
            ControlsWhileDrivingB(); // call the function for controls while driving
        }

        if (!deviceB.isValid) // if device is valid is not true
        {
            GetDevice(); // get device
        }

        List<InputFeatureUsage> featuresB = new List<InputFeatureUsage>(); // create a new list for our input features
        deviceB.TryGetFeatureUsages(featuresB); // get all of the features of any type of device connected
    }

    /// <summary>
    /// 
    /// </summary>
    void FunctionUpdate()
    {
        if (Input.GetKey(KeyCode.Home))
        {
            // home button codes
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            // escape button codes
        }
        if (Input.GetKey(KeyCode.Menu))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// function to lock the blue players XR rig to the car floor
    /// </summary>
    public void LockToCarFloorBlue()
    {
        xRRigBlue.position = blueCarFloor.position; // set the XR rig position from the XR Rig script to the position of the car floor
        xRRigBlue.rotation = blueCarFloor.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car floor
    }

    public void LockToCarRoof()
    {
        usingCarBlue = false;
        xRRigBlue.position = blueCarRoof.position; // set the XR rig position from the XR Rig script to the position of the car roof
        xRRigBlue.rotation = blueCarRoof.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car roof
    }

    /// <summary>
    /// function to lock the red players XR rig to the car floor
    /// </summary>
    //public void LockToCarFloorRed()
    //{
        //xRRigBlue.position = redCarFloor.position; // set the XR rig position from the XR Rig script to the position of the car floor
        //xRRigBlue.rotation = redCarFloor.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car floor
    //}

    /// <summary>
    /// controls that are only active while the using car bool is true
    /// </summary>
    void ControlsWhileDrivingB()
    {
        if (accelerate == false && brake == false) // if accelerate is not equal to true and brake is not equal to true
        {
            idle = true; // set idle to true
            blueCarController.HandleIdleState(); // call our idle state function
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movementVector) && movementVector != Vector2.zero) // get the direction of the analogue stick, if movement vector is not equal to vector2.zero (is moving in a direction)
        {
            brake = true; // set turn brake to true
            idle = false; // set idle to false
            accelerate = false;
            blueCarController.HandleBrakeState();
        }
        else if (movementVector == Vector2.zero) // otherwise if movement vector is equal to vector2.zero (not moving)
        {
            brake = false; // set turn brake to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue) // if the trigger button fo the controller is pressed
        {
            accelerate = true; // set accelerate to true
            idle = false; // set idle to false
            blueCarController.HandleAccelrateState();
        }
        else if (triggerValue != true) // otherwsie if the trigger button is not pressed
        {
            accelerate = false; // set accelerate to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && buttonValue) // if the primary button fo the controller is pressed
        {
            turnL = true; // set turn left to true
        }
        else if (buttonValue == false) // otherwise the button is not being pressed
        {
            turnL = false; // set turn left to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buttonValue2) && buttonValue2) // if the secondary button fo the controller is pressed
        {
            turnR = true;  // set turn right to true
        }
        else if (buttonValue2 == false) // otherwise the button is not being pressed
        {
            turnR = false;  // set turn right to false
        }
    }

    /// <summary>
    /// controls that are only active while the using car bool is true
    /// </summary>
    void ControlsWhileDrivingR()
    {
        if (accelerate == false && brake == false) // if accelerate is not equal to true and brake is not equal to true
        {
            idle = true; // set idle to true
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movementVector) && movementVector != Vector2.zero) // get the direction of the analogue stick, if movement vector is not equal to vector2.zero (is moving in a direction)
        {
            brake = true; // set turn brake to true
            idle = false; // set idle to false
            accelerate = false;
        }
        else if (movementVector == Vector2.zero) // otherwise if movement vector is equal to vector2.zero (not moving)
        {
            brake = false; // set turn brake to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue) // if the trigger button fo the controller is pressed
        {
            accelerate = true; // set accelerate to true
            idle = false; // set idle to false
        }
        else if (triggerValue != true) // otherwsie if the trigger button is not pressed
        {
            accelerate = false; // set accelerate to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && buttonValue) // if the primary button fo the controller is pressed
        {
            turnL = true; // set turn left to true
        }
        else if (buttonValue == false) // otherwise the button is not being pressed
        {
            turnL = false; // set turn left to false
        }

        if (deviceB.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buttonValue2) && buttonValue2) // if the secondary button fo the controller is pressed
        {
            turnR = true;  // set turn right to true
        }
        else if (buttonValue2 == false) // otherwise the button is not being pressed
        {
            turnR = false;  // set turn right to false
        }
    }
}

    // block score script created but not working so removed
    // time score script created but not working so removed
    // total score script created but not working so removed
    //time give a score penalty (e.g. do you go for time or for destorying max # of blocks? Adds to replay value)
