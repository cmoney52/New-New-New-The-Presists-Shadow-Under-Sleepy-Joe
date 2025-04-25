using UnityEngine;

public class GetWood : MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it wood");
        global.WoodCount += 1;
    }
}
