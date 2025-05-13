using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight; // Reference to the light component
    private bool isOn = true; // Track flashlight state
    public int brightness = 20; // Default brightness (1 = dim, higher = brighter)

    void Start()
    {
        flashlight = GetComponentInChildren<Light>(); // Get the Light component
        if (flashlight == null)
        {
            Debug.LogError("No Light component found! Make sure the flashlight has a Light component.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Toggle flashlight
        {
            isOn = !isOn;
            flashlight.intensity = isOn ? brightness : 0; // Set brightness level or turn off
            Debug.Log("Flashlight toggled: " + isOn + " | Brightness: " + brightness);
        }
    }

    public void SetBrightness(int newBrightness)
    {
        brightness = Mathf.Clamp(newBrightness, 1, 10); // Limit brightness between 1 and 10
        if (isOn)
        {
            flashlight.intensity = brightness; // Update brightness if flashlight is on
        }
        Debug.Log("Brightness set to: " + brightness);
    }
}
