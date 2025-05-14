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

    private State OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    public override State RunCurrentState()
    {
        float distanceToMe = Vector3.Distance(transform.position, myPlayer.position);
              
        if (OnTriggerEnter(joeAgroRange) == chaseState) {
            return chaseState;
        }
        else
        {
            Vector3 direction = (randomInt).normalized;
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);
            return this;
        }

    }
}
