using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButtonController : MonoBehaviour
{
    private bool clicked = false;

    public void OnPointerDown()
    {
        clicked = true;
    }

    public void onPointerUp()
    {
        clicked = false;
    }

    public bool GetClicked()
    {
        return clicked;
    }
}
