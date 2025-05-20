using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    void Start()
    {
        if (fpvController != null)
        {
            playerMovementScript = fpvController.GetComponent<FirstPersonMovement>(); // Get First Person Movement script
        }
    }
    public override State RunCurrentState()
    {
        float distanceToMe = Vector3.Distance(transform.position, myPlayer.position);

        if (distanceToMe < stopDistance && !isCaught)
        {
            return attackState;
        }
        else
        {
            Vector3 direction = (myPlayer.position - transform.position).normalized;
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);

            transform.LookAt(new Vector3(myPlayer.position.x + 1, transform.position.y, myPlayer.position.z));
            return this;
        }
    }
}
