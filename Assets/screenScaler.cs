using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class CanvasScalerFix : MonoBehaviour
{
    [Range(0f, 100f)]
    public float margin = 10f; // Default margin in pixels

    private CanvasScaler canvasScaler;

    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();

        // Set the default scaling mode to Scale With Screen Size
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Adjust the reference resolution to account for the margin
        AdjustCanvasScaler();
    }

    public void UpdateMargin(float newMargin)
    {
        margin = newMargin;
        AdjustCanvasScaler();
    }

    void AdjustCanvasScaler()
    {
        if (canvasScaler == null) return;

        // Define the reference resolution (e.g., 1920x1080 by default)
        Vector2 referenceResolution = new Vector2(1920, 1080);

        // Adjust for margins
        referenceResolution.x -= 2f * margin;
        referenceResolution.y -= 2f * margin;

        // Update the CanvasScaler's reference resolution
        canvasScaler.referenceResolution = referenceResolution;

        // Match width or height to fit the screen
        canvasScaler.matchWidthOrHeight = 0.5f; // 0 = Width, 1 = Height, 0.5 = Balanced
    }
}