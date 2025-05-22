using UnityEngine;

public class Global : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoneyCount = 0f;
    public float WoodCount = 0f;
    public float FishCount = 0f;
    public float MineralCount = 0f;
    public float WoodPrice = 1f;
    public float FishPrice = 2f;
    public float MineralPrice = 3f;
    public bool hasFishingRod = false;
    public float whatHolding = 0f; //0 nothing, 1 flashlight, 2 fishing rod

    public string ReturnString(float converting)
    {
        return (converting.ToString());
    }

    void Start()
    {
        hasFishingRod = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
