using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using JetBrains.Annotations;

public class HudController : MonoBehaviour
{
    public static HudController instance;
    public Global global;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;
    [SerializeField] TMP_Text counters;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (E)";
        interactionText.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
    void Update()
    {
        //Updates the text on the screen that shows the amount of money and materials the player has
        counters.text = 
            " $" + global.ReturnString(global.MoneyCount) 
            + "\n Wood:" + global.ReturnString(global.WoodCount) 
            + "\n Fish:" + global.ReturnString(global.FishCount) 
            + "\n Rock:" + global.ReturnString(global.MineralCount)
            + "\n do you have fishing rod?:" + global.hasFishingRod;
    }
}
