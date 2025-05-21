using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public ChaseState chaseState;
    public NavMeshAgent agent;
    public Transform WaypointFolder;
    private Transform[] waypoints;
    private int currentWaypoint = 0;


    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }

    }

    void OnEnable()
    {
        while (GetComponentInParent<NavMeshAgent>() == null) {
            Debug.Log("Not found yet");
        }
        if (!agent.enabled) {
            agent.enabled = true;
        }
        agent = GetComponentInParent<NavMeshAgent>();
        waypoints = new Transform[WaypointFolder.childCount];
        for (int i = 0; i < WaypointFolder.childCount; i++)
        {
            waypoints[i] = WaypointFolder.GetChild(i);
        }
    }

    void Update()
    {
            if (!agent.pathPending && agent.remainingDistance < 1.5F)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypoint].position);
            }
    }

    //State machine method
    public override State RunCurrentState()
    {
        //Getting all of the colliders inside the detection radius
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        //Looping through all of the objects
        foreach (Collider hit in hits)
        {
            //If the player is found switching to chase state
            if (hit.CompareTag("player"))   
            {
                //Switching to chase state
                return chaseState;
            }
        }

        //Staying in the idle state
        return this;
    }
}


