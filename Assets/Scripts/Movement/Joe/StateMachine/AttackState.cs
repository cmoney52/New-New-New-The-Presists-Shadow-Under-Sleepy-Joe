using UnityEngine;

public class AttackState : State
{

    public IdleState idleState;

    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }
    }

    public override State RunCurrentState()
    {
        // Parent the player to Joe
        myPlayer.SetParent(transform);
        isCaught = true;
        holdingPlayer = true;
        catchTime = Time.time;

        // Disable player movement while held
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        // Completely freeze Joe’s rotation so he doesn’t spin
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Move the player to a local position (1 unit in front of Joe)
        //myPlayer.localPosition = new Vector3(0f, 1f, 0.5f);

        // Ensure the player stays attached
        if (holdingPlayer)
        {
            myPlayer.SetParent(transform);
            rb.linearVelocity = bunkerPosition;
        }

        // Release the player after 5 seconds
        if (holdingPlayer && Time.time - catchTime >= holdDuration)
        {
            // Teleport player to the defined coordinates after being unlinked
            myPlayer.position = teleportPosition;

            // Unlink the player from Joe
            myPlayer.SetParent(null);
            holdingPlayer = false;
            isCaught = false;

            // Re-enable player movement after release
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
            }

            // Restore Joe’s rotation freedom after release
            rb.constraints = RigidbodyConstraints.None;
        }

        Debug.Log("I have attacked");
        return idleState;
    }
}
