using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public Transform JoeBiden;
    public Transform playerParentObject;
    public GameObject fpvCam;
    public float waitTime;
    public Vector3 teleportPositionLocation; // Ensure this is assigned properly
    private FirstPersonMovement attackPlayerMovementScript;
    private bool isReleasingPlayer = false;

    private void Start()
    {
        if (fpvCam != null)
        {
            playerMovementScript = fpvCam.GetComponent<FirstPersonMovement>();
        }
    }

    public override State RunCurrentState()
    {
        if (holdingPlayer || isReleasingPlayer)
        {
            return idleState;
        }

        // Parent the player to Joe and disable movement
        myPlayer.SetParent(JoeBiden);
        isCaught = true;
        holdingPlayer = true;
        catchTime = Time.time;

        if (attackPlayerMovementScript != null)
        {
            attackPlayerMovementScript.enabled = false;
        }

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        myPlayer.localPosition = new Vector3(0f, 1f, 0.5f);

        if (holdingPlayer)
        {
            //

            // Start releasing the player using PlayerHoldScripts
            PlayerHoldScript.Instance.StartReleasePlayerCoroutine(
                myPlayer, playerParentObject, waitTime, attackPlayerMovementScript, rb, teleportPosition,
                () => { isReleasingPlayer = false; } // Reset flag after coroutine finishes
            );

            return idleState;
        }

        return this;
    }
}
