using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    //Needed behaviors
    public AttackState attackState;
    private NavMeshAgent agent;
    public Transform target;
    public IdleState idleState;


    //Setting up agent
    void setupAgent() {
        //Sets up agent
        agent = GetComponentInParent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        //Setting up agent if needed
        if (agent == null)
        {
            setupAgent();
        }
        
        //Setting the target location to player position
        agent.SetDestination(target.position);
        
        //Changing to attack state when close
        if (agent.remainingDistance < 1.5f && !agent.pathPending) {
            return attackState;
        }

        //Going out of chase mode if too far away
        if (agent.remainingDistance > 85f) {
            return idleState;
        }

        //Continue in Chase mode
        return this;
    }
}
