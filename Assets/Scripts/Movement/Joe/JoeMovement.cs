using UnityEngine;

public class JoeMovement : MonoBehaviour
{
    public Transform myPlayer;
    public float moveSpeed = 5f;
    public float stopDistance = 1.5f;
    public Rigidbody rb;
    private bool isCaught = false;
    private float catchTime = 0f;
    private bool holdingPlayer = false;
    public Vector3 teleportPosition = new Vector3(0f, 1f, 0f); // Coordinates where player teleports after being unlinked
    private float holdDuration = 5f; // Hold player for 5 seconds
    public GameObject fpvController; // Reference to FPVController
    private MonoBehaviour playerMovementScript; // Reference to First Person Movement script

    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }
    }

    void Update()
    {
        float distanceToMe = Vector3.Distance(transform.position, myPlayer.position);

        if (distanceToMe > stopDistance && !isCaught)
        {
            // Move towards the player
            Vector3 direction = (myPlayer.position - transform.position).normalized;
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);

            transform.LookAt(new Vector3(myPlayer.position.x + 1, transform.position.y, myPlayer.position.z));
        }
        else if (!isCaught)
        {
            // Parent the player to Joe
            Debug.Log("LOCKED ON PLAYER");
            myPlayer.SetParent(transform);
            isCaught = true;
            holdingPlayer = true;
            catchTime = Time.time;

            // Disable player movement while held
            if (playerMovementScript != null)
            {
                Debug.Log("MOVEMENT DISABLED");
                playerMovementScript.enabled = false;
            }

            // Stop Joe from rotating after catching the player
            rb.angularVelocity = Vector3.zero;
        }

        // Ensure the player stays attached
        if (holdingPlayer)
        {
            myPlayer.SetParent(transform);
        }

        // Release the player after 5 seconds
        if (holdingPlayer && Time.time - catchTime >= holdDuration)
        {
            Debug.Log("Player Released");
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
        }
    }
}
