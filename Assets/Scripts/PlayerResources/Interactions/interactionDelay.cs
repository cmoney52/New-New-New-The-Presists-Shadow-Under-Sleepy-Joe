using UnityEngine;
using System.Collections;

public class InteractionDelay : MonoBehaviour
{
    public Interactable interactable;
    public Outline outline;
    public Animator animator;
    public FirstPersonMovement playerMovementScript;
    public float delayTime = 5f;
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
    IEnumerator DelayedInteractionNoAnim()
    {
        interactable.enabled = false;
        outline.enabled = false;
        playerMovementScript.enabled = false;
        yield return new WaitForSeconds(delayTime);
        playerMovementScript.enabled = true;
        outline.enabled = true;
        interactable.enabled = true;
    }

    public void ObjectDelay()
    {
        StartCoroutine(DelayedInteraction());
    }
    public void ObjectDelayNoAnim()
    {
        StartCoroutine(DelayedInteractionNoAnim());
    }
}
