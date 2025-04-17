using UnityEngine;

public class getFish : MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it working");
        global.FishCount += 1;
    }
}
