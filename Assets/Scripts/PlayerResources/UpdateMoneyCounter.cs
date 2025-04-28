using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class UpdateMoneyCounter : MonoBehaviour
{
    public Global global;
    public int counter;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI rockText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Update screen to make sure the game displays the right amount of each material on the start
        moneyText.text = "$" + global.MoneyCount.ToString();
        woodText.text =  global.WoodCount.ToString();
        fishText.text = global.FishCount.ToString();
        rockText.text = global.MineralCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Update screen each frame to match the proper amount of each material
        moneyText.text = "$" + global.MoneyCount.ToString();
        woodText.text = global.WoodCount.ToString();
        fishText.text = global.FishCount.ToString();
        rockText.text = global.MineralCount.ToString();

        //test
    }


}
