﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class XRInputs : MonoBehaviour
{
    [SerializeField]
    XRNode xRNode = XRNode.LeftHand; // reference to the XR node (left hand)
    readonly List<InputDevice> devices = new List<InputDevice>(); // read only list of input devices

    InputDevice device; // reference to our input device
    public bool usingCarBlue = false; // bool for using the blue car being true or not
    public bool usingCarRed = false; // bool for using the red car being true or not
    public bool accelerate; // bool for the car accelerating being true or not
    public bool idle; // bool for if the car being idle is true or not
    public bool brake; // bool for if the car braking is true or not
    public bool turnR; // bool for if the car turning right is true or not
    public bool turnL; // bool for if the car turning left is true or not

    public Transform carFloor; // reference to the transform fo rthe car floor
    public Transform xRRigBlue; // reference to the blue players XR rig
    //public Transform xRRigRed; // reference to the red players XR rig

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices); // get any input devices connected
        device = devices.FirstOrDefault(); // set our device to the first or default in the input device list
    }

    void OnEnable()
    {
        if (!device.isValid) // if not equal to device is valid (there is no device)
        {
            GetDevice(); // call the get device function
        }
    }

    /// <summary>
    /// set trigger condition for collisions with the object this script is attached to
    /// </summary>
    /// <param name="trigger"></param>
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("BluePlayer")) // if the trigger colliding with us has the tag Player
        {
            usingCarBlue = true; // set bool for using car to true
        }
        //if (trigger.CompareTag("RedPlayer")) // if the trigger colliding with us has the tag Player
        //{
           // usingCarRed = true; // set bool for using car to true
        //}
    }

    void OnTriggerExit(Collider trigger)
    {
        // disable the piece of code for mounting when we exit that trigger
        if (trigger.CompareTag("BluePlayer"))
        {
            usingCarBlue = false; // disable the using car bool
        }
        // disable the piece of code for mounting when we exit that trigger
        //if (trigger.CompareTag("RedPlayer"))
        //{
            //usingCarRed = false; // disable the using car bool
        //}
    }

    void Update()
    {
        if (!device.isValid) // if device is valid is not true
        {
            GetDevice(); // get device
        }

        List<InputFeatureUsage> features = new List<InputFeatureUsage>(); // create a new list for our input features
        device.TryGetFeatureUsages(features); // get all of the features of any type of device connected

        if (usingCarBlue == true) // if using the car bool is true
        {
            LockToCarFloorBlue(); // call the lock to car floor function
            ControlsWhileDriving(); // call the function for controls while driving
        }
        //if (usingCarRed == true) // if using the car bool is true
        //{
            //LockToCarFloorRed(); // call the lock to car floor function
            //ControlsWhileDriving(); // call the function for controls while driving
        //}
    }

    /// <summary>
    /// function to lock the blue players XR rig to the car floor
    /// </summary>
    public void LockToCarFloorBlue()
    {
        xRRigBlue.position = carFloor.position; // set the XR rig position from the XR Rig script to the position of the car floor
        xRRigBlue.rotation = carFloor.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car floor
    }

    /// <summary>
    /// function to lock the red players XR rig to the car floor
    /// </summary>
    //public void LockToCarFloorRed()
    //{
        //xRRigRed.position = carFloor.position; // set the XR rig position from the XR Rig script to the position of the car floor
        //xRRigRed.rotation = carFloor.rotation; // set the XR rig rotation from the XR Rig script to the rotation of the car floor
    //}

    /// <summary>
    /// controls that are only active while the using car bool is true
    /// </summary>
    void ControlsWhileDriving()
    {
        if (accelerate != true && brake != true && turnL != true && turnR != true) // if accelerate is not equal to true and brake is not equal to true and turn L & R are not eual to true
        {
            idle = true; // set idle to true
        }

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue) // if the trigger button fo the controller is pressed
        {
            accelerate = true; // set accelerate to true
            idle = false; // set idle to false
        }
        else if (triggerValue != true) // otherwsie if the trigger button is not pressed
        {
            accelerate = false; // set accelerate to false
        }

        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && buttonValue) // if the primary button fo the controller is pressed
        {
            turnL = true; // set turn left to true
            idle = false; // set idle to false
        }
        else if (buttonValue == false) // otherwise the button is not being pressed
        {
            turnL = false; // set turn left to false
        }

        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buttonValue2) && buttonValue2) // if the secondary button fo the controller is pressed
        {
            turnR = true;  // set turn right to true
            idle = false; // set idle to false
        }
        else if (buttonValue2 == false) // otherwise the button is not being pressed
        {
            turnR = false;  // set turn right to false
        }

        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movementVector) && movementVector != Vector2.zero) // get the direction of the analogue stick, if movement vector is not equal to vector2.zero (is moving in a direction)
        {
            brake = true; // set turn brake to true
            idle = false; // set idle to false
        }
        else if (movementVector == Vector2.zero) // otherwise if movement vector is equal to vector2.zero (not moving)
        {
            brake = false; // set turn brake to false
        }
    }
}
