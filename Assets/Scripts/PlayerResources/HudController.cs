using UnityEngine;
using TMPro;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
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
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text rock;
    [SerializeField] TMP_Text log;
    [SerializeField] TMP_Text fish;


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
        money.text = global.ReturnString(global.MoneyCount);
        fish.text = global.ReturnString(global.FishCount);
        log.text = global.ReturnString(global.WoodCount);
        rock.text = global.ReturnString(global.MineralCount);
    }
}
