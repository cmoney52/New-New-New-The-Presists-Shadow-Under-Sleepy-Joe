using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Global global;
    public string objectName = "Object";

    public void Interact()
    {
        Debug.Log("Yes it working");
        global.MoneyCount = global.MoneyCount + (global.WoodCount * global.woodPrice);
        global.MoneyCount = global.MoneyCount + (global.FishCount * global.fishPrice);
        global.MoneyCount = global.MoneyCount + (global.MineralCount * global.mineralPrice);

        global.WoodCount = 0;
        global.FishCount = 0;
        global.MineralCount = 0;
    }
}
