using UnityEngine;
using System.Collections;

public class InteractionDelay : MonoBehaviour
{
    public Interactable interactable;
    public Outline outline;
    public Animator animator;
    public FirstPersonMovement playerMovementScript;
    public float delayTime = 5;
    public GameObject playerCamera;


    private void Start()
    {
        playerMovementScript.enabled = true;
        animator.enabled = false;
        outline.enabled = true;
        interactable.enabled = true;
    }
    IEnumerator DelayedInteraction()
    {
        interactable.enabled = false;
        outline.enabled = false;
        animator.enabled = true;
        playerMovementScript.enabled = false;
        yield return new WaitForSeconds(delayTime);
        playerMovementScript.enabled = true;
        animator.enabled = false;
        outline.enabled = true;
        interactable.enabled = true;
    }
    IEnumerator DelayedInteractionFish()
    {
        interactable.enabled = false;
        outline.enabled = false;
        animator.enabled = true;
        playerMovementScript.enabled = false;
        yield return new WaitForSeconds(3);
        animator.enabled = false;
        yield return new WaitForSeconds(delayTime);
        animator.enabled = true;
        yield return new WaitForSeconds(3);
        playerMovementScript.enabled = true;
        animator.enabled = false;
        outline.enabled = true;
        interactable.enabled = true;
    }

    IEnumerator lockPlayerCamera() 
    {
        if (playerCamera != null)
        {
            FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();
            if (Look != null)
            { 
                Look.sensitivity = 0;
                yield return new WaitForSeconds(delayTime);
                Look.sensitivity = 2;
            }
        }
    }
    public void ObjectDelay()
    {
        StartCoroutine(DelayedInteraction());
    }
    public void ObjectDelayFishingRod()
    {
        StartCoroutine(DelayedInteractionFish());
    }
    public void lockCamera()
    {
        StartCoroutine(lockPlayerCamera());
    }
}
