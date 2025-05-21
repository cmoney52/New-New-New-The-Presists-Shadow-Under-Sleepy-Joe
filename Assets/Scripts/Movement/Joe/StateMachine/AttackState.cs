using UnityEngine;

public class AttackState : State
{
    //Behaviors
    public IdleState idleState;
    public Transform JoeBiden;
    public Transform playerParentObject;
    public GameObject fpvCam;
    public float waitTime;
    public Vector3 teleportPositionLocation; 
    private FirstPersonMovement attackPlayerMovementScript;
    private bool isReleasingPlayer = false;

    private void OnEnable()
    {
        //Getting the FPV camera
        if (fpvCam != null)
        {
            playerMovementScript = fpvCam.GetComponent<FirstPersonMovement>();
        }
    }

    //Running the current state
    public override State RunCurrentState()
    {
        //If the player is being held already or they are being released resetting state
        if (holdingPlayer || isReleasingPlayer)
        {
            return idleState;
        }

        // Parent the player to Joe and disable movement
        myPlayer.SetParent(JoeBiden);
        isCaught = true;
        holdingPlayer = true;
        catchTime = Time.time;

        //Disable the player movement
        if (attackPlayerMovementScript != null)
        {
            attackPlayerMovementScript.enabled = false;
        }

        //Setting the player to be in Joe Biden
        myPlayer.localPosition = new Vector3(0f, 1f, 0.5f);

            // Start releasing the player using PlayerHoldScripts
            PlayerHoldScript.Instance.StartReleasePlayerCoroutine(
                myPlayer, playerParentObject, waitTime, attackPlayerMovementScript, rb, teleportPosition,
                () => { isReleasingPlayer = false; } // Reset flag after coroutine finishes
            );

            //Reset to idle state
            return idleState;
    }
}
