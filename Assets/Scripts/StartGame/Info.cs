using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public Button InfoBtn;
    public GameObject InfoPlane;
    public Button CloseBtn;

    void Start()
    {

        InfoPlane.SetActive(false);


        InfoBtn.onClick.AddListener(UnhidePlane);
        CloseBtn.onClick.AddListener(HidePlane);

    }

    private void UnhidePlane()
    {
        InfoPlane.SetActive(true);
    }
    private void HidePlane()
    {
        InfoPlane.SetActive(false);
    }
}