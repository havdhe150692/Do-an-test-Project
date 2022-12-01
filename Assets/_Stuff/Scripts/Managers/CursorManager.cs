using System;
using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultHand;
    
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Awake()
    {
        Cursor.SetCursor(defaultHand, hotSpot, cursorMode);
    }

    void OnMouseEnter()
    {
        //Cursor.SetCursor(defaultHand, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
