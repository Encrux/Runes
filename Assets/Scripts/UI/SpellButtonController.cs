using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButtonController : MonoBehaviour
{
    private bool clicked = false;
    private int clickState = 0;

    public void toggleClicked()
    {
        clicked = !clicked;
    }

    public bool GetClicked()
    {
        return clicked;
    }

    public int getClickState()
    {
        return clickState;
    }
}
