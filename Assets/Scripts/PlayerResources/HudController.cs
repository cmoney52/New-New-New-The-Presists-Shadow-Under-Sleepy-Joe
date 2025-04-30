using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public static HudController instance;
    Global global;

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
        counters.text = "$" + global.MoneyCount.ToString() + "/n wood" + global.WoodCount.ToString() + "/n fish" + global.FishCount.ToString() + "/n rocks" + global.MineralCount.ToString();
    }
}
