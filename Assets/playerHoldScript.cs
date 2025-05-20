using System;
using System.Collections;
using UnityEngine;

public class PlayerHoldScript : MonoBehaviour
{
    private static PlayerHoldScript instance;

    public static PlayerHoldScript Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("PlayerHold");
                instance = obj.AddComponent<PlayerHoldScript>();
                DontDestroyOnLoad(obj); // Ensure this object persists
            }
            return instance;
        }
    }

    public void StartReleasePlayerCoroutine(Transform player, Transform playerParent, float waitTime, FirstPersonMovement movementScript, Rigidbody rb, Vector3 teleportPosition, Action onReleaseComplete)
    {
        StartCoroutine(ReleasePlayer(player, playerParent, waitTime, movementScript, rb, teleportPosition, onReleaseComplete));
    }


    private IEnumerator ReleasePlayer(Transform player, Transform playerParent, float waitTime, FirstPersonMovement movementScript, Rigidbody rb, Vector3 teleportPosition,Action onReleaseComplete)
    {
        yield return new WaitForSeconds(waitTime);

        // Teleport player
        if (player != null)
        {
            Debug.Log(teleportPosition);
            player.position = teleportPosition;
            player.SetParent(playerParent);
        }

        // Enable movement after release
        if (movementScript != null)
        {
            movementScript.enabled = true;
        }

        // Restore rotation freedom
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        onReleaseComplete?.Invoke();
    }
}
