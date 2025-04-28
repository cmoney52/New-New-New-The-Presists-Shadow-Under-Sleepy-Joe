using UnityEngine;

public class Global : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoneyCount = 0f;
    public float WoodCount = 0f;
    public float FishCount = 0f;
    public float MineralCount = 0f;

    public float woodPrice = 1;
    public float fishPrice = 4;
    public float mineralPrice = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyCount += 1;
    }
}
