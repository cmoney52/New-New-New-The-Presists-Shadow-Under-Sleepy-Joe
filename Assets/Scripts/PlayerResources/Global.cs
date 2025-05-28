using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    public float MoneyCount = 0f;
    public float WoodCount = 0f;
    public float FishCount = 0f;
    public float MineralCount = 0f;
    public float WoodPrice = 1f;
    public float FishPrice = 2f;
    public float MineralPrice = 3f;
    public bool hasFishingRod = false;
    public bool houseFinished = false;
    public int whatHolding = 0;
    public int lifeCount = 3;

    public TextMeshProUGUI lifeCountTXT;
    public string ReturnString(float converting)
    {
        return (converting.ToString());
    }

    void Start()
    {
        hasFishingRod = false;
    }


    // Update is called once per frame
    void Update()
    {
        lifeCountTXT.text = lifeCount.ToString();
    }

     public void updateLifeCount ()
    {
        lifeCount--;
    }
    public int getLifeCount()
    {
        return lifeCount;
    }


}
