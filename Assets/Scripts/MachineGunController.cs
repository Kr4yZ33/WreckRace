using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunController : MonoBehaviour
{
    public GameManager gameManager;
    public bool okToFireBlueMG = false;

    public bool idleCarCannons;
    public bool shootingCarCannons;
    public bool openCarCannons;
    public bool reloadCarCannons;

    public AnimationHandlerMachineGun animationHandlerMachineGun;
    public enum ShootingStates { Idle, Shoot, Open, Reload } // our different shooting states
    public ShootingStates currentShootingState; // the current shooting state our car is in

    void Update()
    {
        if (idleCarCannons == true)
        {
            HandleIdleState();
        }

        if (shootingCarCannons == true)
        {
            HandleShootState();
        }

        if (openCarCannons == true)
        {
            HandleOpenState();
        }

        if (reloadCarCannons == true)
        {
            HandleReloadState();
        }

        if (gameManager.usingCarBlue == false)
        {
            okToFireBlueMG = false;
            return;
        }
        else if (gameManager.usingCarBlue == true)
        {
            okToFireBlueMG = true;
            HandleBlueMGFiringState();
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

    void HandleBlueMGFiringState()
    {
        if (shootingCarCannons != true && openCarCannons != true && reloadCarCannons != true)
        {
            idleCarCannons = true; // set idle to true
        }
    }

    public void HandleMGOpenState()
    {
        if (okToFireBlueMG == true)
        {
            openCarCannons = true;  // set open car cannons to true
            idleCarCannons = false;
        }
    }

    public void HandleMGReloadState()
    {
        if (okToFireBlueMG == true)
        {
            openCarCannons = false;
            idleCarCannons = false;
            reloadCarCannons = true;  // set reload car cannons to true
        }
    }

    public void ShootBlueMG()
    {
        if (okToFireBlueMG == true)
        {
            reloadCarCannons = false;
            openCarCannons = false;
            idleCarCannons = false;
            shootingCarCannons = true; // set shooting car cannons to true
        }
    }
}
