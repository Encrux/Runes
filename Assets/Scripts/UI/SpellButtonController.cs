using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButtonController : MonoBehaviour
{
    private bool clicked = false;
    private int clickState = 0;
    private bool mouseHovering = false;

    public void toggleClicked()
    {
        clicked = !clicked;
    }

    public void OnPointerEnter() 
    {
        mouseHovering = true;
    }

    public void OnPointerExit()
    {
        mouseHovering = false;
    }

    public bool GetClicked()
    {
        return clicked;
    }

    public int getClickState()
    {
        return clickState;
    }

    public bool IsMouseHovering()
    {
        return mouseHovering;
    }
}
