using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float raycastRange = 5f; // Range of the raycast
    public LayerMask interactableLayer; // Layer for interactable objects

    void Update()
    {
        // Cast a ray forward from the player's position
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastRange, interactableLayer))
            {
                // Check if the object hit by the ray has an InteractableObject component
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
