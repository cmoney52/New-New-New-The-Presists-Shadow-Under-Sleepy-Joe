using UnityEngine;

public class CursorSwitcher : MonoBehaviour
{
    public Texture2D normalCursor;
    public Texture2D clickingCursor;

    public Vector2 hotspot = Vector2.zero;

    void Start()
    {
        SetCursor(normalCursor);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            SetCursor(clickingCursor);
        }
        else
        {
            SetCursor(normalCursor);
        }
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}