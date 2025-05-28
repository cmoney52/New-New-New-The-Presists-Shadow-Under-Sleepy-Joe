using UnityEngine;

public class keepThisFlippinBunkerInPlace : MonoBehaviour
{
    public Transform bunker;
    Vector3 fixedPosition = new Vector3(653.68f, 59.523f, 315.1f);

    void Update()
    {
        bunker.position = fixedPosition; // Locks object in place
    }
}
