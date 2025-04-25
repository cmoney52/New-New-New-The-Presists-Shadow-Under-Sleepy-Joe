using UnityEngine;

public class GetMinerals: MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it mineral");
        global.MineralCount += 1;
    }
}
