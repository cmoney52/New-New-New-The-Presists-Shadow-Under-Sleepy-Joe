using UnityEngine;

public class Outline : MonoBehaviour
{
    public Camera playerCamera; // Assign the player's camera in Unity
    public float maxDistance = 5f; // Maximum distance for interaction
    private Renderer lastHighlightedObject;

    void Update()
    {
        HandleHighlight();
    }

    void HandleHighlight()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();

            if (renderer != null)
            {
                if (lastHighlightedObject != null && lastHighlightedObject != renderer)
                {
                    RemoveOutline(lastHighlightedObject);
                }

                ApplyOutline(renderer);
                lastHighlightedObject = renderer;
            }
        }
        else if (lastHighlightedObject != null)
        {
            RemoveOutline(lastHighlightedObject);
            lastHighlightedObject = null;
        }
    }

    void ApplyOutline(Renderer renderer)
    {
        if (renderer.material.HasProperty("_OutlineWidth"))
        {
            renderer.material.SetFloat("_OutlineWidth", 5.0f); // Adjust outline thickness
        }
    }

    void RemoveOutline(Renderer renderer)
    {
        if (renderer.material.HasProperty("_OutlineWidth"))
        {
            renderer.material.SetFloat("_OutlineWidth", 0f); // Remove outline
        }
    }
}
