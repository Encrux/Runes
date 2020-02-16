using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Composition based Spell-System with am abstract Spell class
public abstract class Spell : MonoBehaviour
{
    public abstract void Cast();
}
