using UnityEngine;

public class GetFish : InteractableObject
{
    public Global global;
    public string objectName = "fishGet";

    public void Interact()
    {
        Debug.Log("Yes it fish");
        global.FishCount += 1;
    }
}
