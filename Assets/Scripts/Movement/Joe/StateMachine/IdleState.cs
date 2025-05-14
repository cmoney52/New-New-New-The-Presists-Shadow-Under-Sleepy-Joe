using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }

    }

    public override State RunCurrentState()
    {
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
