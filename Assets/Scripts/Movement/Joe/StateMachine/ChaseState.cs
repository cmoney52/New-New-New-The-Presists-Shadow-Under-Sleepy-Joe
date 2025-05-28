using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public AttackState attackState;
    public IdleState idleState;
    private NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }
        setupAgent();
    }

    void setupAgent() {
            agent = GetComponentInParent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        if (!SunriseSimulation.IsDaytime) { 
        if (agent == null) { 
            setupAgent();
        }

        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }
        agent.SetDestination(target.position);

        if (agent.remainingDistance > 80 || SunriseSimulation.IsDaytime) { 
            return idleState;
        }
        if (agent.remainingDistance < 1.5f && !agent.pathPending) {
            return attackState;
        }
        return this;
    }
        return idleState;
    }
}
