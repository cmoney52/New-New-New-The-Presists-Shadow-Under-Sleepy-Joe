using UnityEngine;

public class getMinerals: MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it working");
        global.MineralCount += 1;
    }
}
