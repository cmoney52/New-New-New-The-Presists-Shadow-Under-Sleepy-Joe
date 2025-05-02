using UnityEngine;
using UnityEngine.UI;

public class IMGCycle : MonoBehaviour
{
    public Image displayImage; 
    public Sprite[] images;    
    public Button leftButton;  
    public Button rightButton; 

    private int currentIndex = 0; 

    void Start()
    {
        UpdateImage();

            leftButton.onClick.AddListener(NextImage);

            rightButton.onClick.AddListener(PreviousImage);
    }

    private void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        UpdateImage();
    }

    private void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (images.Length > 0 && displayImage != null)
        {
            displayImage.sprite = images[currentIndex];
        }
    }
}