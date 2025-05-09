using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerFix : MonoBehaviour
{
    [Range(0f, 100f)]
    public float margin = 10f; // Default margin in pixels

    void Start()
    {
        ScaleCanvas();
    }

    void UpdateMargin(float newMargin)
    {
        margin = newMargin;
        ScaleCanvas();
    }

    void ScaleCanvas()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null || rectTransform.parent == null) return;

        RectTransform parentRectTransform = rectTransform.parent.GetComponent<RectTransform>();
        if (parentRectTransform == null) return;

        // Keep default anchor and pivot (no centering)
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // Calculate independent scales for X and Y based
        // on pixel margins
        float parentWidth = parentRectTransform.rect.width * 4;
        float parentHeight = parentRectTransform.rect.height * 4;

        int windowWidth = Screen.width;
        int windowHeight = Screen.height;

        float scaleX = (windowWidth/(parentWidth + 2f * margin));
        float scaleY = (windowHeight/(parentHeight + 2f * margin));
        float scale = Mathf.Min(scaleX, scaleY);

        // Apply independent scaling to ensure equal margins
        rectTransform.localScale = new Vector3(scale, scale, 1f);
        rectTransform.sizeDelta = Vector2.zero; // Ensure canvas fills adjusted area
    }
}
