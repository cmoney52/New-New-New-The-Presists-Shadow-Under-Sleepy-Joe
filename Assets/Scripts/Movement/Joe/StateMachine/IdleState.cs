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
            Debug.Log("Waypoint attempting to update");
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypoint].position);
            }
    }


    public override State RunCurrentState()
    {
        Debug.Log("In Idle strat");
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("player"))   
            {
                return chaseState;
            }
        }
        return this;

    }
}


