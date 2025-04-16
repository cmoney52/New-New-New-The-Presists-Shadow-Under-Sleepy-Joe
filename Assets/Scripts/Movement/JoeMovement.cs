using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class JoeMovement : MonoBehaviour
{
    public Transform myPlayer;  
    public float moveSpeed = 5f;  
    public float stopDistance = 1.5f;
    public Rigidbody rb;

    void Update()
    {
      
            float distanceToMe = Vector3.Distance(transform.position, myPlayer.position);

            if (distanceToMe > stopDistance)
            {
            // Move towards the the camera/position
            Vector3 direction = (myPlayer.position - transform.position).normalized;
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);


            transform.LookAt(new Vector3(myPlayer.position.x +1, transform.position.y, myPlayer.position.z)); //joe will now look at you :)
            }
        }
    }
