using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Global global;

    //texts
    public TextMeshProUGUI moneyTXT;
    public TextMeshProUGUI logTXT;
    public TextMeshProUGUI rockTXT;
    public TextMeshProUGUI FishTXT;


    //Sell inputs
    public TMP_InputField logInput;
    public TMP_InputField rockInput;
    public TMP_InputField fishInput;

    //audio 
    public AudioSource audioSource;
    public AudioClip SellSound;
    void Start()
    {
        
    }

    void Update()
    {
        moneyTXT.text = global.MoneyCount.ToString();
        logTXT.text = global.WoodCount.ToString();
        rockTXT.text = global.MineralCount.ToString();
        FishTXT.text = global.FishCount.ToString();


    }

    public void sellWood()
    {
        if (global.WoodCount > 0 && global.WoodCount >= float.Parse(logInput.text))
        {
            global.WoodCount -= float.Parse(logInput.text);
            global.MoneyCount += float.Parse(logInput.text) * 3;
            audioSource.PlayOneShot(SellSound);


        }
    }

    public void sellRock()
    {
        if (global.MineralCount > 0 && global.MineralCount >= float.Parse(rockInput.text))
        {
            global.MineralCount -= float.Parse(rockInput.text);
            global.MoneyCount += float.Parse(rockInput.text) * 5;
            audioSource.PlayOneShot(SellSound);


        }
    }

    public void sellFish()
    {
        if (global.FishCount > 0 && global.FishCount >= float.Parse(fishInput.text))
        {
            global.FishCount -= float.Parse(fishInput.text);
            global.MoneyCount += float.Parse(fishInput.text) * 7;
            audioSource.PlayOneShot(SellSound);


        }
    }
}
