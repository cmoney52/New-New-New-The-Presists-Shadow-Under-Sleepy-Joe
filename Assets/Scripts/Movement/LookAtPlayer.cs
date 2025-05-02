using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 rotationOffset;

    void Update()
    {
       
            Vector3 direction = player.position - transform.position;

            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            targetRotation *= Quaternion.Euler(rotationOffset);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}