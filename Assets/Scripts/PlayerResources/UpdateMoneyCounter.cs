using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class UpdateMoneyCounter : MonoBehaviour
{
    public Global global;
    public int counter;

    public TextMeshProUGUI moneyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Update screen to make sure the game displays the right amount of money on the start
        moneyText.text = "$" + global.MoneyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Update screen each frame to match the proper money amount
        moneyText.text = "$" + global.MoneyCount.ToString();

    }

    public void  updateMoney()
    {
        global.MoneyCount++; 
    }
}
