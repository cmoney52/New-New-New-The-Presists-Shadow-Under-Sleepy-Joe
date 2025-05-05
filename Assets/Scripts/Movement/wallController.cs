using UnityEngine;

public class WallController : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDropping = false;
    public float dropSpeed = 2f;
    public float dropDistance = 5f; // Adjust how far the wall should drop

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!SunriseSimulation.IsDaytime && !isDropping)
        {
            isDropping = true;
            StartCoroutine(DropWall());
        }
        else if (SunriseSimulation.IsDaytime && isDropping)
        {
            isDropping = false;
            ResetWall();
        }
    }

    System.Collections.IEnumerator DropWall()
    {
        float targetY = initialPosition.y - dropDistance;

        while (transform.position.y > targetY)
        {
            transform.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);
            yield return null;
        }
    }

    void ResetWall()
    {
        transform.position = initialPosition;
    }
}

