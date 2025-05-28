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
    public Transform dungeonButtons;
    public Transform[] buttonsFolder;
    private Interactable interactScript;
    public Global global;

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

        

        for (int i = 0; i < dungeonButtons.childCount; i++)
        {
            buttonsFolder[i] = dungeonButtons.GetChild(i);
        }

        int randomInt = Random.Range(1, dungeonButtons.childCount);

        Interactable buttonScript = buttonsFolder[randomInt].GetComponent<Interactable>();
        buttonScript.enabled = true;

        if (holdingPlayer)
        {
            // Start releasing the player using PlayerHoldScripts
            PlayerHoldScript.Instance.StartReleasePlayerCoroutine(
                myPlayer, playerParentObject, waitTime, attackPlayerMovementScript, rb, teleportPosition,
                () => { isReleasingPlayer = false; } // Reset flag after coroutine finishes
            );

            //re-disable all dungeon buttons
            for (int i = 0; i < dungeonButtons.childCount; i++)
            {
                Interactable InteractScript = buttonsFolder[i].GetComponent<Interactable>();
                InteractScript.enabled = false;
            }
            return idleState;
        }

        return this;
    }
}
