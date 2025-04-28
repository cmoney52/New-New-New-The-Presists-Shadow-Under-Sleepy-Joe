using UnityEngine;

public class GetFish : MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it fish");
        global.FishCount += 1;
    }
}
