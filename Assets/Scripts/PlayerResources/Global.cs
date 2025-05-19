using UnityEngine;

public class Global : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoneyCount = 0f;//amount of cash the player has
    public float WoodCount = 0f; //amount of wood the player has
    public float FishCount = 0f; //amount of fish the player has
    public float MineralCount = 0f; //amount of rocks player has
    public float WoodPrice = 1f; //price of wood
    public float FishPrice = 2f; //price of fish
    public float MineralPrice = 3f; //price of rocks
    public bool hasFishingRod = false; //vecomes true once the player collects the fishing rod
    public float whatHolding = 0f; //what the player is holding (0 - nothing, 1 - flashlight, 2 - fishing rod)

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
