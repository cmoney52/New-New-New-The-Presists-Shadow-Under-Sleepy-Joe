using UnityEngine;

public class WallController : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDropping = false;
    public float dropSpeed = 2f;
    public float dropDistance = 8f; // Adjust how far the wall should drop

    void Start()
    {
        initialPosition = transform.parent.position;
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

        while (transform.parent.position.y > targetY)
        {
            Debug.Log("Trying to move");
            transform.parent.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);
            yield return null;
        }
    }

    void ResetWall()
    {
        transform.parent.position = initialPosition;
    }


}


