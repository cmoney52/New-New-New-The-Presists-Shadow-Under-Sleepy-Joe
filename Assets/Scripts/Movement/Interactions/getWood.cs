using UnityEngine;

public class getWood : MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it working");
        global.WoodCount += 1;
    }
}
