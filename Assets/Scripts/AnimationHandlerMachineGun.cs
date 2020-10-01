using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandlerMachineGun : MonoBehaviour
{
    public enum AnimationState { Idle, Shoot, Open, Reload } // the different states of our animation
    public AnimationState currentAnimationState; // the current state our animator is in

    public Animator animator; // a reference to our animator component

    /// <summary>
    /// handles updating the animation state of our machine gun
    /// </summary>
    public AnimationState CurrentState
    {
        get
        {
            return currentAnimationState; // return current animation state
        }
        set
        {
            currentAnimationState = value; // set the current animation state to the value of the Current State

            {
                if (animator != null) // if there is an animator
                {
                    UpdateAnimator(); // run function UpdateAnimator
                }
                else
                {
                    //Debug.LogError("No animator has been assigned"); // Otherwise return a debug error there is noAnimator assigned.
                    return;
                }
            }
        }
    }

    /// <summary>
    /// update our animator to match the current state of our character
    /// </summary>
    private void UpdateAnimator()
    {
        switch (currentAnimationState)
        {
            case AnimationState.Idle:
                {
                    // reset our animator back to idle
                    ResetToIdle();
                    break;
                }
            case AnimationState.Shoot:
                {
                    ResetToIdle();
                    // set our animator to the shoot state
                    animator.SetBool("Shoot", true);
                    break;
                }
            case AnimationState.Open:
                {
                    ResetToIdle();
                    // set our animator to the brake animation
                    animator.SetBool("DoOpen", true);
                    break;
                }
            case AnimationState.Reload:
                {
                    ResetToIdle();
                    // set our animator to the ignitiong animation
                    animator.SetBool("DoReload", true);
                    break;
                }
        }
    }

    /// <summary>
    /// reset our animator to the idle state.
    /// </summary>
    private void ResetToIdle()
    {
        animator.SetBool("DoOPen", false);
        animator.SetBool("DoReload", false);
        animator.SetBool("Shoot", false);
    }
}
