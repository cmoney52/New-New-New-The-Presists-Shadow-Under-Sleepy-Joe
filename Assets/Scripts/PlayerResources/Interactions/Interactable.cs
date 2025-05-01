using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;
    public Global global;
    [SerializeField] TMP_Text interactionText;

    public UnityEvent onInteraction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }
    public void Interact()
    {
        onInteraction.Invoke();
    }
    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void getWood()
    {
        global.WoodCount += 1;
    }

    public void getMineral()
    {
        global.MineralCount += 1;
    }

    public void getFish()
    {
        if (global.hasFishingRod)
        {
            //Play animation
            global.FishCount += 1;
        }
    }
    public void getFishingRod()
    {
        if (global.hasFishingRod)
        {
            interactionText.text = "You Already Have a Fishing Rod";
            return;
        }
        else
        {

            global.hasFishingRod = true;
        }
    }

    public void sell()
    {
        //Handle selling wood
        global.MoneyCount += global.WoodCount * global.WoodPrice;
        global.WoodCount = 0;

        //Handle selling fish
        global.MoneyCount += global.FishCount * global.FishPrice;
        global.FishCount = 0;

        //Handle selling Minerals/rocks
        global.MoneyCount += global.MineralCount * global.MineralPrice;
        global.MineralCount = 0;
    }

}
