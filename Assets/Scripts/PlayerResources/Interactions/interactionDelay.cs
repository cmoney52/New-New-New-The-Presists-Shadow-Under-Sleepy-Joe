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
    public Global global;


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
    //Start fishing rod code
    IEnumerator DelayedInteractionFish()
    {
        FirstPersonLook Look = playerCamera.GetComponent<FirstPersonLook>(); //declare camera

        if (global.hasFishingRod && global.whatHolding == 2) //if you have and are holding the fishing rod
        {
            //disable player movement in all capacity
            interactable.enabled = false;
            outline.enabled = false;
            playerMovementScript.enabled = false;
            Look.sensitivity = 0;

            //manage the animation and timing
            playCast();
            returnToDefault();
            yield return new WaitForSeconds(delayTime);
            playReel();
            returnToDefault();

            ///enable player movement and such
            Look.sensitivity = 2;
            playerMovementScript.enabled = true;
            animator.enabled = false;
            outline.enabled = true;
            interactable.enabled = true;
        }
    }
    public void playCast()
    {
        animator.Play("Cast");
        Debug.Log("casted");
    }

    public void playReel()
    {
        animator.Play("Reel");
        Debug.Log("Reeling");
    }

    public void returnToDefault()
    {
        animator.Play("Default");
        Debug.Log("Back to default");
    }
    //end fishing rod code

    public void ObjectDelay()
    {
        StartCoroutine(DelayedInteraction());
    }
    public void ObjectDelayFishingRod()
    {
        StartCoroutine(DelayedInteractionFish());
    }
}
