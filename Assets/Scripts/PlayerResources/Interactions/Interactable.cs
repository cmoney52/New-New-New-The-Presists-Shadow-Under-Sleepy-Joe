using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using BlockadeLabsSDK;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public GameObject fishingRod;
    public string message;
    public Global global;
    [SerializeField] TMP_Text interactionText;
    public Image imgFishingRod;

    public UnityEvent onInteraction;
    public GameObject sleepyTimeTerminal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
        imgFishingRod.gameObject.SetActive(false);
        sleepyTimeTerminal.gameObject.SetActive(false);

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
        fishingRod.tag = "disabled";
        global.hasFishingRod = true;
        imgFishingRod.gameObject.SetActive(true);



    }

    public void sleepyTime ()
    {
        sleepyTimeTerminal.gameObject.SetActive(true);
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
