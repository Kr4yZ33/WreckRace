using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunController : MonoBehaviour
{

    public XRInputs xRInputs;
    public AnimationHandlerMachineGun animationHandlerMachineGun;
    public enum ShootingStates { Idle, Shoot, Open, Reload } // our different driving states
    public ShootingStates currentShootingState; // the current driving state our car is in

    void Update()
    {
        if (xRInputs.idleCarCannons == true)
        {
            HandleIdleState();
        }

        if (xRInputs.shootingCarCannons == true)
        {
            HandleShootState();
        }

        if (xRInputs.openCarCannons == true)
        {
            HandleOpenState();
        }

        if (xRInputs.reloadCarCannons == true)
        {
            HandleReloadState();
        }
    }


    /// <summary>
    /// function that handles our Idle state
    /// </summary>
    void HandleIdleState()
    {
        if (currentShootingState == ShootingStates.Idle) // if the current shooting state is equal to the shooting State Idle
        {
            if (animationHandlerMachineGun.CurrentState != AnimationHandlerMachineGun.AnimationState.Idle) // if the current state of the animation handler is not eqaul to Idle
            {
                animationHandlerMachineGun.CurrentState = AnimationHandlerMachineGun.AnimationState.Idle;  // set the animation handler current state to Idle
            }
        }
    }

    void HandleShootState()
    {
        if (currentShootingState == ShootingStates.Shoot) // if the current shooting state is equal to the shooting State Idle
        {
            if (animationHandlerMachineGun.CurrentState != AnimationHandlerMachineGun.AnimationState.Shoot) // if the current state of the animation handler is not eqaul to shoot
            {
                animationHandlerMachineGun.CurrentState = AnimationHandlerMachineGun.AnimationState.Shoot;  // set the animation handler current state to shoot
            }
        }
    }

    void HandleOpenState()
    {
        if (currentShootingState == ShootingStates.Open) // if the current shooting state is equal to the shooting State Idle
        {
            if (animationHandlerMachineGun.CurrentState != AnimationHandlerMachineGun.AnimationState.Open) // if the current state of the animation handler is not eqaul to open
            {
                animationHandlerMachineGun.CurrentState = AnimationHandlerMachineGun.AnimationState.Open;  // set the animation handler current state to open
            }
        }
    }
    void HandleReloadState()
    {
        if (currentShootingState == ShootingStates.Reload) // if the current shooting state is equal to the shooting State reload
        {
            if (animationHandlerMachineGun.CurrentState != AnimationHandlerMachineGun.AnimationState.Reload) // if the current state of the animation handler is not eqaul to reload
            {
                animationHandlerMachineGun.CurrentState = AnimationHandlerMachineGun.AnimationState.Reload;  // set the animation handler current state to reload
            }
        }
    }
}
