using UnityEngine;

public class itemSwitch : MonoBehaviour
{
    public Global global;
    public GameObject fishingRod;
    public GameObject flashlight;

    private void Start()
    {
        global.whatHolding = 0; //set held item to nothing on start
    }
    private void Update()
    {
        // once you press x, put away held item
        if (Input.GetKeyDown(KeyCode.X))
        {
            global.whatHolding = 0;
        }

        //once you press q, cycle held item
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (global.whatHolding == 0) //if youre holding nothing
            {
                global.whatHolding = 1; //equip flashlight
            }
            else if (global.whatHolding == 1 && global.hasFishingRod) //if youre holding flashlight and have the fishing rod
            {
                global.whatHolding = 2; //equip fishing rod
            }
            else if (global.whatHolding == 2) //if youre holding the fishing rod
            {
                global.whatHolding = 1; //equip flashlight
            }
            else
            {
                global.whatHolding = 1; //if somehow none of these conditions are met take flashlight out
            }
        }

        if (global.whatHolding == 0)
        {
            fishingRod.SetActive(false);
            flashlight.SetActive(false);

        }
        else if (global.whatHolding == 1)
        {
            flashlight.SetActive(true);
            fishingRod.SetActive(false);
        }
        else if (global.whatHolding == 2)
        {
            flashlight.SetActive(false);
            fishingRod.SetActive(true);
        }
    }
}