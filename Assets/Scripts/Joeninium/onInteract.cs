using UnityEngine;

public class onInteract : MonoBehaviour
{
    public bool Joeninium = false;
    public GameObject imgJoeninium1;
    public GameObject imgJoeninium2;
    public GameObject imgJoeninium3;
    public Material auraMaterial;





    public GameObject joeOutline;
    public int joeLevel = 0;
    void Start()
    {
        imgJoeninium1.gameObject.SetActive(false);
        imgJoeninium2.gameObject.SetActive(false);
        imgJoeninium3.gameObject.SetActive(false);

        joeOutline.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Interact(GameObject interactedObject)
    {
        Destroy(interactedObject);
        joeOutline.gameObject.SetActive(true);
        joeLevel++;
        if( joeLevel ==1)
        {
            imgJoeninium1.gameObject.SetActive(true);
            auraMaterial.SetFloat("_EdgeStrength", .55f);
        }
        if (joeLevel == 2)
        {
            imgJoeninium2.gameObject.SetActive(true);
            auraMaterial.SetFloat("_EdgeStrength", .3f);

        }
        if (joeLevel == 3)
        {
            imgJoeninium3.gameObject.SetActive(true);
            auraMaterial.SetFloat("_EdgeStrength", 0f);


        }

    }
}
