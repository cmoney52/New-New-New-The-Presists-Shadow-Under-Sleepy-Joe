using UnityEngine;

public class joeBidenCageMovement : MonoBehaviour
{
    // Variables
    public bool hasTeleportedToday;
    public Rigidbody rb;
    public int inCageXPosition;
    public int inCageYPosition;
    public int inCageZPosition;
    public int outCageXPosition;
    public int outCageYPosition;
    public int outCageZPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Initialize variables if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Access the IsDaytime property from the SunriseSimulation script
        bool isntDaytime = SunriseSimulation.IsDaytime;

        if (isntDaytime && !hasTeleportedToday)
        {
            transform.position = new Vector3(inCageXPosition, inCageYPosition, inCageZPosition);
            hasTeleportedToday = true;
        }
        else if (!isntDaytime && hasTeleportedToday)
        {
            transform.position = new Vector3(outCageXPosition, outCageYPosition, outCageZPosition);
            hasTeleportedToday = false;
        }
    }
}
