using UnityEngine;

public abstract class State: MonoBehaviour
{

    // Variables
   
    public Rigidbody rb;
    public Collider joeAgroRange;
    public Transform myPlayer;
    public float moveSpeed = 5f;
    public float stopDistance = 1.5f;
    protected bool isCaught = false;
    protected float catchTime = 0f;
    protected bool holdingPlayer = false;
    public Vector3 teleportPosition = new Vector3(0f, 15f, 0f); // Coordinates where player teleports after being unlinked
    public Vector3 bunkerPosition = new Vector3(420.2946f, 16.4f, 430.9027f);//Coordinates where joe will run to
    protected float holdDuration = 5f; // Hold player for 5 seconds
    public GameObject fpvController; // Reference to FPVController
    protected MonoBehaviour playerMovementScript; // Reference to First Person Movement script
    //public Vector3 randomInt = new Vector3(Random.Range(-200, 200), 0, Random.Range(-280, 280));
    public Vector3 randomInt = new Vector3(0, 0, 0);
    public float detectionRadius = 3f; //detection Radius for Joe

    //declare stateRunner
    public abstract State RunCurrentState();

    private void Update()
    {
            RunCurrentState();
    }
}
