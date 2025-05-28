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

        if (holdingPlayer)
        {
            buttonsFolder = new Transform[dungeonButtons.childCount];
            for (int i = 0; i < dungeonButtons.childCount; i++)
            {
                buttonsFolder[i] = dungeonButtons.GetChild(i);
            }
            int randomInt = Random.Range(1, dungeonButtons.childCount);

            for (int i = 0; i < dungeonButtons.childCount; i++)
            {
                DisableScript(buttonsFolder[i]);
            }
            EnableScript(buttonsFolder[randomInt]);

            //used to enable the script of the given Object
            void EnableScript(Transform obj)
            {
                Interactable script = obj.GetComponent<Interactable>();
                if (script != null)
                {
                    script.enabled = true;
                }
            }
            //used to disable the script of the given Object
            void DisableScript(Transform obj)
            {
                Interactable script = obj.GetComponent<Interactable>();
                if (script != null)
                {
                    script.enabled = false;
                }
            }
            //Takes away a life
            global.updateLifeCount();

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
