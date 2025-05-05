using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class UpdateMoneyCounter : MonoBehaviour
{
    public Global global;
    public int counter;

    public TextMeshProUGUI moneyText;
    void Start()
    {
        moneyText.text = "$" + global.MoneyCount.ToString();
    }

    void Update()
    {
        moneyText.text = "$" + global.MoneyCount.ToString();

    }

    public void  updateMoney()
    {
        global.MoneyCount++; 
    }
}
