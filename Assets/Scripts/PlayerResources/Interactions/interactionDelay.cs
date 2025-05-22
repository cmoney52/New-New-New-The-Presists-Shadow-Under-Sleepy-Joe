using UnityEngine;
using System.Collections;

public class InteractionDelay : MonoBehaviour
{
    public Interactable interactable;
    public Outline outline;
    public Animator animator;
    public FirstPersonMovement playerMovementScript;
    public float delayTime = 5f;
    public float fishDelay = 2.5f;
    public GameObject playerCamera;
    


    private void Start()
    {
        playerMovementScript.enabled = true;
        animator.enabled = false;
        outline.enabled = false;
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
        FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>();

        interactable.enabled = false;
        outline.enabled = false;
        playerMovementScript.enabled = false;
        Look.sensitivity = 0;

        animator.enabled = true;
        yield return new WaitForSeconds(fishDelay);
        animator.enabled = false;
        yield return new WaitForSeconds(delayTime);
        animator.enabled = true;
        yield return new WaitForSeconds(fishDelay);
        animator.enabled = false;

        playerMovementScript.enabled = true;
        outline.enabled = true;
        interactable.enabled = true;
        Look.sensitivity = 2;
    }

    public void ObjectDelay()
    {
        StartCoroutine(DelayedInteraction());
    }
    public void ObjectDelayFish()
    {
        StartCoroutine(DelayedInteractionFish());
    }
}
